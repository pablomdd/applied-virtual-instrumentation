"""
Programa que leer un valor del ADC de la Raspberry Pi Pico
cada segundo.
El valor de despliega en una pantalla OLED y se envía por 
el puerto serie y se guarda en una tajera MicroSD.
"""
from machine import Pin, UART, Timer, I2C, SPI
# OLED
import ssd1306 import SSD1306
import time
import framebuf
import sdcard
import uos

# FTDI serial to USB for plotting with Python
uart0 = UART(0, baudrate=9600, tx=Pin(0), rx=Pin(1))
# Blink internal LED
led = Pin(25, Pin.OUT)
# Timer to do a callback method
timer = Timer()
adc = ADC(0)

# Values to convert the signal to volts
logic_level = 3.3
board_res = (2**16) - 1

# Resolution of OLED (square OLED type SSD1306)
WIDTH, HEIGHT = 128, 64

i2c = I2C(0)
time.sleep(0.1)

# i2c for the display communication
oled = SSD1306_I2C(WIDTH, HEIGHT, i2c)
# Raspbery Pi logo
buffer = bytearray(b"\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00|?\x00\x01\x86@\x80\x01\x01\x80\x80\x01\x11\x88\x80\x01\x05\xa0\x80\x00\x83\xc1\x00\x00C\xe3\x00\x00~\xfc\x00\x00L'\x00\x00\x9c\x11\x00\x00\xbf\xfd\x00\x00\xe1\x87\x00\x01\xc1\x83\x80\x02A\x82@\x02A\x82@\x02\xc1\xc2@\x02\xf6>\xc0\x01\xfc=\x80\x01\x18\x18\x80\x01\x88\x10\x80\x00\x8c!\x00\x00\x87\xf1\x00\x00\x7f\xf6\x00\x008\x1c\x00\x00\x0c \x00\x00\x03\xc0\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00")

fb = framebuf.FrameBuffer(buffer, 32, 32, framebuf.MONO_HSLB)

# SD Card
# Assign chip select CS Pin
cs = Pin(13, Pin.OUT)
spi = SPI(1, baudrate=1000000, polarity=0, phase=0, bits=8,
          firstbit=SPI.MSB, sck=Pin(10), mosi=Pin(11), miso=(12))

# Initialize SD Card
sd = sdcard.SDCard(spi, cs)

# Mount filesystem
vfs = uos.VfsFat(sd)
uso.mount(vfs, "/sd")

values = []
count = 0


def tick(timer):
    global led, count, values
    led.toggle()
    # Read from ADC
    ai0 = adc.read_u16()
    # Sen value to serial port
    str_ai0 = str(ai0) + "\r\n"
    uart0.write(str_ai0)

    # Clear screen
    oled.fill(0)
    oled.blit(fb, 96, 0)
    # Print to screen
    oled.text("Rasberry Pi", 5, 5)
    oled.text("Pico", 5, 15)
    oled.text("ADC0", 5, 25)
    val = float(ai0) * (logic_level / board_res)
    str_val = str(val) + "V"
    oled.text(str_val, 5, 40)

    # Show info in OLED
    oled.show()

    if count < 10:
        values.append(str(val) + "\r\n")
    if count == 100:
        with open("sd/data/.txt", "w") as file:
            for i in range(len(values)):
                file.write(values[i])
        values = []
        print("Save data done")

    if count > 100:
        count = 200
    count += 1


# Timer frequency of 1Hz, or a period of 1s
timer.init(freq=1, mode=Timer.PERIODIC, callback=tick)

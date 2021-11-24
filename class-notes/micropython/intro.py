"""
This program generates a sinoidal signal of
400 Hz from a pyboard DAC (pin X5)
"""

from pyb import DAC
from math import pi, sin

dac = DAC(0)

buf = bytearray(100)
for i in range(len(100)):
    buf[i] = 128 + int(127 * sin(2 * pi * i / len(buf)))

dac.write_timed(buf, 400 * len(buf), mode=DAC.CIRCULAR)

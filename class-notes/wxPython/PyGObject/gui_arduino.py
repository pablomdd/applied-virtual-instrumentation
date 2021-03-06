from gi.repository import Gtk, GLib, Gio
from matplotlib.backends.backend_gtk3agg import (
    FigureCanvasGTK3Agg as FigureCanvas)
from matplotlib.figure import Figure
import numpy as np
import time
import threading
import serial
import glob
import sys
import gi
gi.require_version('Gtk', '3.0')


class AppWindow(Gtk.ApplicationWindow):
    def __init__(self, *args, **kwargs) -> None:
        super().__init__(*args, **kwargs)
        self.timer = None

        self.set_border_width(10)
        hpaned = Gtk.Paned.new(Gtk.Orientation.HORIZONTAL)
        vbox = Gtk.Box(orientation=Gtk.Orientation.VERTICAL, spacing=5)

        # Label Serial Port
        serial_port_label = Gtk.Label.new("Serial Port:")
        vbox.pack_start(serial_port_label, False, True, 0)
        # Combobox Serial Port
        ports = self.getSerialPorts()
        port_combobox = Gtk.ComboBoxText()
        port_combobox.set_entry_text_column(0)
        port_combobox.connect("changed", self.on_port_change)
        for port in ports:
            port_combobox.append_text(str(port))
        port_combobox.set_active(0)
        vbox.pack_start(port_combobox, False, False, 0)

        # Label Samples
        samples_label = Gtk.Label.new("Samples: ")
        vbox.pack_start(samples_label, False, False, 0)

        # Spinbox samples
        samples_spin = Gtk.SpinButton.new_with_range(1, 1000, 1)
        samples_spin.set_digits(0)
        samples_spin.connect("value-changed", self.on_samples_changed)
        vbox.pack_start(samples_spin, False, False, 0)

        self.start_button = Gtk.Button.new_with_label("Start")
        self.start_button.connect("clicked", self.on_button_start)
        vbox.pack_start(self.start_button, False, False, 0)

        self.stop_button = Gtk.Button.new_with_label("Stop")
        self.stop_button.connect("clicked", self.on_button_stop)
        vbox.pack_start(self.stop_button, False, False, 0)

        self.save_button = Gtk.Button.new_with_label("Save")
        self.save_button.connect("clicked", self.on_button_save)
        vbox.pack_start(self.save_button, False, False, 0)

        hpaned.add1(vbox)

        # App vars initialization
        self.port = None
        self.baud_rate = 9600
        self.logic_level = 5.0
        self.board_resolution = 1023

        # Example init plot
        self.fig = Figure(figsize=(5, 4), dpi=100)
        self.ax = self.fig.add_subplot()
        self.t = np.arange(0.0, 3.0, 0.015)
        self.v = ((self.logic_level / 2) + (self.logic_level/2)) * \
            np.sin(2*np.pi*self.t)
        self.ax.plot(self.t, self.v, 'C1o--')
        self.ax.set_xlabel("Time (s)")
        self.ax.set_ylabel("Voltage (V)")
        self.canvas = FigureCanvas(self.fig)
        self.canvas.set_size_request(300, 250)
        hpaned.add2(self.canvas)

        self.samples = 1
        self.micro_board = None
        self.time_interval = 0.5  # 5s
        self.values = []

        self.add(hpaned)
        self.set_size_request(800, 600)
        self.show_all()

    def on_draw(self, x, y):
        self.ax.clear()
        self.ax.plot(x, y, 'C1o--')
        self.ax.set_xlabel("Time (s)")
        self.ax.set_ylabel("Voltage (V)")
        self.canvas.draw()

    def on_button_clicked(self, button):
        self.destroy()

    def getSerialPorts(self) -> list:
        if sys.platform.startswith('win'):
            ports = ['COM%s' % (i + 1) for i in range(256)]
        elif sys.platform.startswith('linux') or sys.platform.startswith('cygwin'):
            # this excludes your current terminal "/dev/tty"
            ports = glob.glob('/dev/tty[A-Za-z]*')
        elif sys.platform.startswith('darwin'):
            ports = glob.glob('/dev/tty.*')
        else:
            raise EnvironmentError('Unsupported platform')

        result = []
        for port in ports:
            try:
                s = serial.Serial(port, 9600)
                s.close()
                result.append(port)
            except:
                pass
        return result

    def on_port_change(self, combo):
        available_port = str(combo.get_active_text())
        if available_port != None:
            self.port = available_port
        else:
            self.port = None
            self.on_no_port_available(self)

    def on_no_port_available(self, widget):
        port_dialog = Gtk.MessageDialog(transient_for=self,
                                        flags=0,
                                        message_type=Gtk.MessageType.ERROR,
                                        buttons=Gtk.ButtonsType.OK,
                                        text="No serial port available",
                                        title="Serial Port")
        port_dialog.run()
        port_dialog.destroy()

    def on_samples_changed(self, samples_spin):
        self.samples = samples_spin.get_value_as_int()

    def on_button_start(self, widget):
        print("Start")
        self.timer = threading.Thread(target=self.get_time)
        self.event = threading.Event()
        self.timer.daemon = True
        self.timer.start()

    def get_time(self):
        time_value = value = count = 0
        self.t = np.array([])
        self.v = np.array([])
        self.start_button.hide()
        self.save_button.hide()
        self.stop_button.show()
        take_data = False

        if self.micro_board != None:
            self.micro_board.close()
        if self.port != None:
            try:
                self.micro_board = serial.Serial(
                    str(self.port), self.baud_rate, timeout=1)
                time.sleep(1)
                self.micro_board.reset_input_buffer()
                take_data = True
            except:
                if not self.event.is_set():
                    print("Stop")
                    self.event.set()
                    self.timer = None
                GLib.idle_add(self.on_failed_connection)
                take_data = False
        if take_data:
            if time_value == 0:
                print("Time(s) \t Voltage(V)")
            while not self.event.is_set():
                if count >= self.samples:
                    print("Stop")
                    self.event.set()
                    self.timer = None
                    if self.micro_board != None:
                        self.micro_board.close()
                    break
                try:
                    temp = str(self.micro_board.readline().decode('cp437'))
                    temp = temp.replace("\n", "")
                    value = (float(temp) * self.logic_level /
                             self.board_resolution)
                    print_console = "Time: " + str(time_value) + " (s)\t"
                    print_console += "Voltage: " + \
                        "{0:.3f}".format(value) + " (V)"
                    print(print_console)
                    self.values.append(str(time_value) +
                                       "," + "{0:.4f}".format(value))
                    self.t = np.append(self.t, time_value)
                    self.v = np.append(self.v, value)
                    self.on_draw(self.t, self.v)
                except:
                    pass
                time.sleep(self.time_interval)
                count += 1
                time_value += self.time_interval
            time.sleep(0.5)
            self.start_button.show()
            self.save_button.show()
            self.stop_button.hide()

    def on_faild_connection(self):
        failed_connection_dialog = Gtk.MessageDialog(transient_for=self,
                                                     flags=0,
                                                     message_type=Gtk.MessageType.ERROR,
                                                     text="Board communication error. No data will be taken",
                                                     title="Serial Error")
        failed_connection_dialog.run()
        failed_connection_dialog.destroy()

    def on_button_stop(self, widget):
        print("Stop Button")
        self.event.set()
        self.timer = None

    def on_button_save(self, widget):
        print("Save Button")
        self.save_button.hide()
        self.start_button.hide()
        save_dialog = Gtk.FileChooserDialog(
            title="Save file as...", parent=self, action=Gtk.FileChooserAction.SAVE)
        save_dialog.add_buttons(Gtk.STOCK_CANCEL,
                                Gtk.ResponseType.CANCEL,
                                Gtk.STOCK_SAVE,
                                Gtk.ResponseType.OK)
        filter_csv = Gtk.FileFilter()
        filter_csv.add_pattern("*.CSV")
        filter_csv.set_name("CSV")
        save_dialog.add_filter(filter_csv)
        response = save_dialog.run()

        if response == Gtk.ResponseType.OK:
            filename = save_dialog.get_filename()
            if not filename.endswith(".csv"):
                filename += ".csv"
            new_file = open(filename, 'w')
            new_file.write("Time(s),Voltage(V)" + "\n")
            for i in range(len(self.values)):
                new_file.write(self.values[i] + "\n")
            new_file.close()
        save_dialog.destroy()
        self.start_button.show()
        self.save_button.show()


class Application(Gtk.Application):
    def __init__(self, *args, **kwargs) -> None:
        super().__init__(*args, **kwargs)
        self.window = None

    def do_activate(self):
        if not self.window:
            self.window = AppWindow(
                application=self, title="Single Point Measurement - PyGtk")
        self.window.show_all()
        self.window.save_button.hide()
        self.window.stop_button.hide()
        self.window.present()

    def do_shutdown(self):
        if self.window.micro_board != None:
            try:
                self.micro_board.close()
            except:
                pass
        print("Byeee")
        Gtk.Application.do_shutdown(self)
        if self.window:
            self.window.destroy()


if __name__ == "__main__":
    app = Application()
    app.run(sys.argv)

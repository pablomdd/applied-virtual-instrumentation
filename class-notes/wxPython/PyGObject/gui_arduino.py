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

        self.save_button = Gtk.Button.new_with_label("save")
        self.save_button.connect("clicked", self.on_button_save)
        vbox.pack_start(self.save_button, False, False, 0)

        hpaned.add1(vbox)

        # App vars initialization
        self.port = None
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
        self.time_interval = 500  # 500ms
        self.values = []

        self.add(hpaned)
        self.set_size_request(800, 600)
        self.show_all()

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
        pass

    def on_button_stop(self, widget):
        pass

    def on_button_save(self, widget):
        pass


class Application(Gtk.Application):
    def __init__(self, *args, **kwargs) -> None:
        super().__init__(*args, **kwargs)
        self.window = None

    def do_activate(self):
        if not self.window:
            self.window = AppWindow(application=self, title="Grocery List")
        self.window.show_all()
        self.window.present()


if __name__ == "__main__":
    app = Application()
    app.run(sys.argv)

import matplotlib.pyplot as plt
from numpy.core.fromnumeric import take
import gi
import sys
import glob
import serial
from pyfirmata import Arduino, util
import threading
import time
import numpy as np
from matplotlib.figure import Figure
from matplotlib.backends.backend_gtk3agg import (
    FigureCanvasGTK3Agg as FigureCanvas)
from gi.repository import Gtk, GLib, Gio
gi.require_version('Gtk', '3.0')
plt.style.use('ggplot')


class AppWindow(Gtk.ApplicationWindow):

    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)

        self.timer = None

        self.set_border_width(10)
        hpaned = Gtk.Paned.new(Gtk.Orientation.HORIZONTAL)
        vbox = Gtk.Box(orientation=Gtk.Orientation.VERTICAL, spacing=5)

        com_port_label = Gtk.Label.new("Serial Port")
        vbox.pack_start(com_port_label, False, True, 0)
        self.port = None

        ports = self.getSerialPorts()
        port_combo = Gtk.ComboBoxText()
        port_combo.set_entry_text_column(0)
        port_combo.connect("changed", self.on_port_changed)
        for port in ports:
            port_combo.append_text(str(port))
        port_combo.set_active(0)
        self.port = str(port_combo.get_active_text())
        vbox.pack_start(port_combo, False, False, 0)

        label_samples = Gtk.Label.new("Samples")
        vbox.pack_start(label_samples, False, False, 0)

        samples_spin = Gtk.SpinButton.new_with_range(1, 1000, 5)
        samples_spin.set_digits(0)
        samples_spin.connect("value-changed", self.on_samples_changed)
        vbox.pack_start(samples_spin, False, False, 0)

        label_threshold = Gtk.Label.new("Threshold (0 - 5000mV)")
        vbox.pack_start(label_threshold, False, False, 0)
        threshold_spin = Gtk.SpinButton.new_with_range(0, 5000, 100)
        threshold_spin.set_digits(0)
        threshold_spin.connect("value-changed", self.on_threshold_changed)
        vbox.pack_start(threshold_spin, False, False, 0)
        self.threshold = threshold_spin.get_value_as_int()

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

        self.logic_level = 5.0
        self.board_resolution = 1023

        self.fig = Figure(figsize=(5, 4), dpi=100)
        self.ax = self.fig.add_subplot()
        self.t = np.arange(0.0, 3.0, 0.015)
        self.v = ((self.logic_level/2) + (self.logic_level/2)
                  * np.sin(2*np.pi*self.t))
        self.ax.plot(self.t, self.v, 'r-')
        self.ax.set_xlabel("Time (s)")
        self.ax.set_ylabel("Voltage (V)")
        self.canvas = FigureCanvas(self.fig)
        self.canvas.set_size_request(300, 250)
        hpaned.add2(self.canvas)

        # Vars init
        self.samples = 1
        self.micro_board = None
        self.time_interval = 0.5
        self.values = []

        self.add(hpaned)
        self.set_size_request(1000, 600)
        self.show_all()

    def on_port_changed(self, combo):
        available_port = str(combo.get_active_text())
        if (available_port != None):
            self.port = available_port
            print("Selected port: ", self.port)
        else:
            self.port = None
            self.on_no_port_available(self)

    def on_no_port_available(self, widget):
        port_dialog = Gtk.MessageDialog(transcient_for=self,
                                        flags=0,
                                        message_type=Gtk.MessageType.ERROR,
                                        buttons=Gtk.ButtonsType.OK,
                                        text="No serial port available!",
                                        title="COM Port")
        port_dialog.run()
        port_dialog.destroy()

    def on_samples_changed(self, samples_spin):
        self.samples = samples_spin.get_value_as_int()

    def on_threshold_changed(self, threshold_spin):
        self.threshold = threshold_spin.get_value_as_int()

    def on_draw(self, x, y1, y2, y_ref):
        self.ax.clear()
        self.ax.plot(x, y1, 'C1o--')
        self.ax.plot(x, y2, 'C2o--')
        self.ax.plot(x, y_ref, 'C3o--')
        self.ax.set_xlabel("Time (s)")
        self.ax.set_ylabel("Voltage (V)")
        self.canvas.draw()

    def on_button_start(self, button):
        print("Start")
        self.timer = threading.Thread(target=self.get_time)
        self.event = threading.Event()
        self.timer.daemon = True
        self.timer.start()

    def get_time(self):
        time_value = 0
        count = 0
        valor1 = 0
        valor2 = 0
        self.x = np.array([])
        self.y1 = np.array([])
        self.y2 = np.array([])
        self.y_ref = np.array([])

        self.start_button.hide()
        self.save_button.hide()
        self.stop_button.show()

        take_data = False
        if (self.micro_board != None):
            self.micro_board.exit()
        if (self.port != None):
            try:
                self.micro_board = Arduino(self.port)
                time.sleep(1)
                self.it = util.Iterator(self.micro_board)
                self.it.start()
                self.a0 = self.micro_board.get_pin('a:0:i')
                self.a2 = self.micro_board.get_pin('a:1:i')
                self.d11 = self.micro_board.get_pin('d:11:o')
                self.d12 = self.micro_board.get_pin('d:12:o')
                take_data = True
            except:
                if(not self.event.is_set()):
                    print("Stop sampling.")
                    self.event.set()
                    self.timer = None
                GLib.idle_add(self.on_failed_connection)
                take_data = False
        if(take_data == True):
            if(time_value == 0):
                print("Tiempo (s) \t Tension (V)")
            while(not self.event.is_set()):
                if(count >= self.samples):
                    print('stop')
                    self.event.set()
                    self.timer = None
                    if(self.micro_board != None):
                        self.micro_board.exit()
                    break
                try:
                    valor1 = self.a0.read()
                    valor2 = self.a2.read()
                    valor1 = (float(valor1) * (self.logic_level))
                    valor2 = (float(valor2) * (self.logic_level))
                    str_console = "Tiempo:" + str(time_value)+" (s)"+"\t"
                    str_console += "Tension 1: " + \
                        "{0:.5f}".format(valor1)+" (V)\t"
                    str_console += "Tension 2: " + \
                        "{0:.5f}".format(valor2)+" (V)"
                    print(str_console)
                    self.values.append(str(time_value)+"," +
                                       "{0:05f}".format(valor1)+"," +
                                       "{0:05f}".format(valor2))
                    self.x = np.append(self.x, time_value)
                    self.y1 = np.append(self.y1, valor1)
                    self.y2 = np.append(self.y2, valor2)
                    self.y_ref = np.append(self.y_ref, self.threshold / 1000.0)
                    self.on_draw(self.x, self.y1, self.y2, self.y_ref)

                    if(valor1 > self.threshold / 1000.0):
                        self.d11.write(1)
                    else:
                        self.d11.write(0)
                    if(valor2 > self.threshold / 1000.0):
                        self.d12.write(1)
                    else:
                        self.d12.write(0)
                except:
                    pass

                time.sleep(self.time_interval)
                count = count + 1
                time_value = time_value + self.time_interval
            time.sleep(0.5)
            self.start_button.show()
            self.save_button.show()
            self.stop_button.hide()

    def on_failed_connection(self):
        failed_connection_dialog = Gtk.MessageDialog(transcient_for=self, flags=0,
                                                     message_type=Gtk.MessageType.ERROR,
                                                     buttons=Gtk.ButtonsType.OK,
                                                     text="Board communication error, no data will be taken!",
                                                     title="COM Error")
        failed_connection_dialog.run()
        failed_connection_dialog.destroy()

    def on_button_stop(self, button):
        print('stop')
        self.event.set()
        self.timer = None

    def on_button_save(self, button):
        print('save')
        self.start_button.hide()
        self.save_button.hide()
        save_dialog = Gtk.FileChooserDialog(title="Save file as...",
                                            parent=self,
                                            action=Gtk.FileChooserAction.SAVE)
        save_dialog.add_buttons(
            Gtk.STOCK_CANCEL,
            Gtk.ResponseType.CANCEL,
            Gtk.STOCK_SAVE,
            Gtk.ResponseType.OK)
        filter_csv = Gtk.FileFilter()
        filter_csv.add_pattern("*.csv")
        filter_csv.set_name("CSV")
        save_dialog.add_filter(filter_csv)
        response = save_dialog.run()
        if(response == Gtk.ResponseType.OK):
            filename = save_dialog.get_filename()+".csv"
            new_file = open(filename, 'w')
            new_file.write("Time_(s),Voltaje_(V)"+"\n")
            for i in range(len(self.values)):
                new_file.write(self.values[i]+"\n")
            new_file.close()
        save_dialog.destroy()
        self.start_button.show()
        self.save_button.show()

    def getSerialPorts(self) -> list:
        if (sys.platform.startswith('win')):
            ports = ["COM%s" % (i+1) for i in range(256)]
        elif(sys.platform.startswith('Linux') or sys.platform.startswith('cygwin')):
            ports = glob.glob("/dev/tty[A-Za-z]*")
        elif(sys.platform.startswith('darwin')):
            ports = glob.glob("/dev/tty.*")
        else:
            raise EnvironmentError('Unsupported platform')
        result = []

        for port in ports:
            try:
                s = serial.Serial(port)
                s.close()
                result.append(port)
            except:
                pass
        return result

    def on_button_clicked(self, button):
        self.destroy()


class Application(Gtk.Application):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.window = None

    def do_activate(self):
        if (not self.window):
            self.window = AppWindow(application=self,
                                    title="Tarea 2 | PyGObject")
        self.window.show_all()
        self.window.save_button.hide()
        self.window.stop_button.hide()
        self.window.present()

    def do_shutdown(self):
        if(self.window.micro_board != None):
            try:
                self.micro_board.close()
            except:
                pass
        print("Byee")
        Gtk.Application.do_shutdown(self)
        if(self.window):
            self.window.destroy()


if(__name__ == "__main__"):
    app = Application()
    app.run(sys.argv)

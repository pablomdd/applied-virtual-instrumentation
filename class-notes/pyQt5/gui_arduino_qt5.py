import sys
import glob
import numpy as np
from numpy.lib.function_base import select
import serial
from matplotlib.figure import Figure
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg
from PyQt5.QtCore import Qt, QTimer
from PyQt5.QtWidgets import (QApplication, QMainWindow, QVBoxLayout, QGridLayout,
                             QLabel, QWidget, QSpinBox, QComboBox, QPushButton,
                             QMessageBox, QFileDialog)
import matplotlib
matplotlib.use('Qt5Agg')


class MplCanvas(FigureCanvasQTAgg):
    def __init__(self, parent=None, width=5, height=4, dpi=100):
        fig = Figure(figsize=(width, height), dpi=dpi)
        self.axes = fig.add_subplot(111)
        self.axes.set_xlabel("Time (s)")
        self.axes.set_ylabel("Voltage (V)")
        super(MplCanvas, self).__init__(fig)


class MainWindow(QMainWindow):
    def __init__(self) -> None:
        super().__init__()
        self.setWindowTitle("SPM PyQt5 and Arduino")

        # Main Layout
        main_layout = QVBoxLayout()
        # Custom Matplotlib Graph
        self.canvas = MplCanvas(self, width=5, height=4, dpi=100)
        main_layout.addWidget(self.canvas)
        # Label Serial Ports
        control_layout = QGridLayout()
        label_serial_port = QLabel("Serial Port")
        control_layout.addWidget(label_serial_port, 0, 0)
        # Combo Box Serial Ports
        self.serial_port = ""
        self.cb_port = QComboBox()
        self.cb_port.addItems(self.getSerialPorts())
        self.cb_port.activated.connect(self.add_serial_port)
        control_layout.addWidget(self.cb_port, 1, 0)
        # Label Samples
        label_samples = QLabel("Samples: ")
        control_layout.addWidget(label_samples, 0, 1)
        # Spin Samples
        spb_samples = QSpinBox()
        spb_samples.setMinimum(1)
        spb_samples.setMaximum(1000)
        spb_samples.setSingleStep(1)
        spb_samples.valueChanged.connect(self.on_change_spb_samples)
        control_layout.addWidget(spb_samples, 1, 1)
        # Button Start
        self.btn_start = QPushButton("Start")
        self.btn_start.clicked.connect(self.on_click_start)
        control_layout.addWidget(self.btn_start, 1, 2)
        # Button Stop
        self.btn_stop = QPushButton("Stop")
        self.btn_stop.clicked.connect(self.on_click_stop)
        control_layout.addWidget(self.btn_stop, 1, 3)
        # Button Save
        self.btn_save = QPushButton("Save")
        self.btn_save.clicked.connect(self.on_click_save)
        control_layout.addWidget(self.btn_save, 1, 4)
        # Main Widget
        main_layout.addLayout(control_layout)
        widget = QWidget()
        widget.setLayout(main_layout)
        self.setCentralWidget(widget)
        self.btn_start.show()
        self.btn_stop.hide()
        self.btn_save.hide()
        # Class Vars initialization
        self.count = 0
        self.micro_board = None
        self.high_value_board = 5.0
        self.board_resolution = 1023
        self.period = 500  # ms

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

    def add_serial_port(self):
        self.serial_port = str(self.cb_port.currentText())

    def on_change_spb_samples(self, val_samples):
        self.samples = val_samples

    def on_click_start(self):
        self.stop_acq = False
        try:
            self.micro_board = serial.Serial(
                str(self.serial_port), 9600, timeout=1)
        except:
            dialog_board = QMessageBox()
            dialog_board.setWindowTitle("Serial Port Error")
            msg_dialog_board = "The board cannot be read"
            msg_dialog_board += "or it wasn't connected"
            dialog_board.setText(msg_dialog_board)
            dialog_board.setStandardButtons(QMessageBox.Ok)
            dialog_board.setIcon(QMessageBox.Warning)
            dialog_board.exec()
            self.micro_board = None

        if self.serial_port != "" and self.micro_board != None:
            self.btn_start.hide()
            self.btn_stop.show()
            self.btn_save.hide()

            if self.count == 0:
                self.time_val = 0
                self.values = []
                self.x = np.asarray([])
                self.y = np.asarray([])
                if self.micro_board != None:
                    self.micro_board.reset_input_buffer()
                self.timer = QTimer()
                self.timer.setInterval(self.period)
                self.timer.timeout.connect(self.update_plot)

                self.timer.start()
                print()
                print("Time(s)\t Voltage(V)")

    def update_plot(self):
        # print(self.count)
        # Serial reading
        try:
            temp = str(self.micro_board.readline().decode(
                'cp437')).replace("\n", "")
            value = float(temp) * self.high_value_board / self.board_resolution
            msg_console = str(self.time_val/1000.0) + " (s) \t"
            msg_console += "{0:.5f}".format(value) + " (V)"
            print(msg_console)
            self.values.append(str(self.time_val/1000.0) +
                               "," + "{0:.5f}".format(value))
            self.canvas.axes.cla()
            self.x = np.append(self.x, self.time_val / 1000.0)
            self.y = np.append(self.y, value)
            self.canvas.axes.set_xlabel("Time (s)")
            self.canvas.axes.set_ylabel("Voltage (V)")
            self.canvas.axes.plot(self.x, self.y, 'C1o--')
            self.canvas.draw()

        except Exception as e:
            print(e)

        self.count += 1
        self.time_val += self.period

        # Stop condition
        if self.count >= self.samples or self.stop_acq == True:
            self.timer.stop()
            self.count = 0
            self.stop_acq = False
            if self.micro_board != None:
                self.micro_board.close()
            self.btn_start.show()
            self.btn_stop.hide()
            self.btn_save.show()

    def on_click_stop(self):
        print("Stop")
        self.stop_acq == True

    def on_click_save(self):
        self.btn_start.hide()
        self.btn_save.hide()

        options = QFileDialog.Options()
        options |= QFileDialog.DontUseNativeDialog
        filename, _ = QFileDialog.getSaveFileName(
            self, "QFileDialog.getSaveFileName()", "", "All Files (*);;csv Files (*.csv)", options=options)
        if filename:
            file = open(filename, 'w')
            file.write("Time_(s),Volage(V)\n")
            for i in range(len(self.values)):
                file.write(self.values[i] + "\n")
            file.close()
        self.btn_start.show()
        self.btn_save.show()


if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = MainWindow()
    window.show()
    app.exec_()

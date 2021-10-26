import sys
import glob
import numpy as np
import serial
from matplotlib.figure import Figure
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg
from PyQt5.QtCore import Qt, QTimer
from PyQt5.QtWidgets import (QApplication, QMainWindow, QVBoxLayout, QGridLayout,
                             QLabel, QWidget, QSpinBox, QComboBox, QPushButton,
                             QMessageBox, QFileDialog)
import matplotlib
matplotlib.use('QTAgg')


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
        self.cb_port.activated.connect(self.add_port)
        control_layout.addWidget(self.cb_port, 1, 0)
        # Label Samples
        label_samples = QLabel("Samples: ")
        control_layout.addWidget(label_samples, 0, 1)
        # Spin Samples
        spb_samples = QSpinBox()
        spb_samples.setMinimum(1)
        spb_samples.setMaximum(1000)
        spb_samples.setSingleStep(1)
        spb_samples.valueChange.connect(self.on_change_spb_samples)
        control_layout.addWidget(spb_samples, 1, 1)

        # Main Widget
        widget = QWidget()
        widget.setLayout(main_layout)
        self.setCentralWidget(widget)

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


if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = MainWindow()
    window.show()
    app.exec_()

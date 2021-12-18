import numpy as np
import serial
from pyfirmata import Arduino, util
import sys
import glob
from matplotlib.figure import Figure
from matplotlib.backends.backend_qt5agg import FigureCanvasQTAgg
from PyQt5.QtCore import Qt, QTimer
from PyQt5.QtWidgets import (
    QApplication,
    QMainWindow,
    QVBoxLayout,
    QGridLayout,
    QLabel,
    QWidget,
    QSpinBox,
    QComboBox,
    QPushButton,
    QMessageBox,
    QFileDialog
)
import matplotlib
matplotlib.use('Qt5Agg')
matplotlib.style.use('ggplot')


class MplCanvas(FigureCanvasQTAgg):
    def __init__(self, parent=None, width=5, height=4, dpi=100):
        fig = Figure(figsize=(width, height), dpi=dpi)
        self.axes = fig.add_subplot()
        self.axes.set_xlabel("Time (s)")
        self.axes.set_ylabel("Voltage (V)")
        super(MplCanvas, self).__init__(fig)


class MainWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Tarea 2 | Qt5")
        self.canvas = MplCanvas(self, width=5, height=4, dpi=100)
        main_layout = QVBoxLayout()
        main_layout.addWidget(self.canvas)
        control_layout = QGridLayout()

        lbl_port = QLabel("Port")
        control_layout.addWidget(lbl_port, 0, 0)

        self.com_port = ""
        self.cb_port = QComboBox()
        self.cb_port.addItems(self.getSerialPorts())
        self.cb_port.activated.connect(self.add_port)
        self.add_port()
        control_layout.addWidget(self.cb_port, 1, 0)

        lbl_samples = QLabel("Samples")
        control_layout.addWidget(lbl_samples, 0, 1)
        spb_samples = QSpinBox()
        spb_samples.setMinimum(10)
        self.samples = 10
        spb_samples.setMaximum(1000)
        spb_samples.setSingleStep(5)
        spb_samples.valueChanged.connect(self.spb_samples_changed)
        control_layout.addWidget(spb_samples, 1, 1)

        lbl_umbral = QLabel("Threshold (0 - 5000 mV)")
        control_layout.addWidget(lbl_umbral, 0, 2)
        spb_threshold = QSpinBox()
        spb_threshold.setMinimum(0)
        spb_threshold.setMaximum(5000)
        spb_threshold.setSingleStep(100)
        spb_threshold.valueChanged.connect(self.spb_threshold_changed)
        control_layout.addWidget(spb_threshold, 1, 2)
        self.threshold = 0

        self.btn_start = QPushButton("Start")
        self.btn_start.clicked.connect(self.start_acquisition)
        control_layout.addWidget(self.btn_start, 1, 3)

        self.btn_stop = QPushButton("Stop")
        self.btn_stop.clicked.connect(self.stop_acquisition)
        control_layout.addWidget(self.btn_stop, 1, 4)

        self.btn_save = QPushButton("Save")
        self.btn_save.clicked.connect(self.save_file)
        control_layout.addWidget(self.btn_save, 1, 5)

        main_layout.addLayout(control_layout)

        widget = QWidget()
        widget.setLayout(main_layout)
        self.setCentralWidget(widget)

        self.btn_start.show()
        self.btn_save.hide()
        self.btn_stop.hide()

        self.count = 0
        self.micro_board = None
        self.high_value_board = 5.0
        self.board_resolution = 1023
        self.period = 500
        # self.samples = 0
        # self.threshold = 0

    def save_file(self):
        self.btn_start.hide()
        self.btn_save.hide()
        options = QFileDialog.Options()
        options |= QFileDialog.DontUseNativeDialog
        filename, _ = QFileDialog.getSaveFileName(self,
                                                  "QFileDialog.getSaveFileName()", "",
                                                  "csv Files(*.csv);;All Files (*)",
                                                  options=options)
        filename = filename+".csv"
        if(filename):
            file = open(filename, 'w')
            file.write("Time_(s),Voltaje_(V)"+"\n")
            for i in range(len(self.values)):
                file.write(self.values[i]+"\n")
            file.close()
        self.btn_start.show()
        self.btn_save.show()

    def stop_acquisition(self):
        print("Stop")
        self.stp_acq = True

    def start_acquisition(self):
        print("Start")
        self.stp_acq = False
        try:
            self.board = Arduino(self.com_port)
            self.it = util.Iterator(self.board)
            self.it.start()
            self.a0 = self.board.get_pin('a:0:i')
            self.a1 = self.board.get_pin('a:1:i')
            self.d11 = self.board.get_pin('d:11:o')
            self.d12 = self.board.get_pin('d:12:o')
        except:
            dlg_board = QMessageBox()
            dlg_board.setWindowTitle("Serial Port Error.")
            str_dlg_board = "The board cannot be read."
            str_dlg_board += "or it wasn't selected."
            dlg_board.setText(str_dlg_board)
            dlg_board.setStandardButtons(QMessageBox.Ok)
            dlg_board.setIcon(QMessageBox.Warning)
            dlg_board.exec_()
            self.board = None

        if(self.com_port != "" and self.board != None):
            self.btn_start.hide()
            self.btn_save.hide()
            self.btn_stop.show()
            if(self.count == 0):
                self.time_val = 0
                self.values = []
                self.x = np.asarray([])
                self.y1 = np.asarray([])
                self.y2 = np.asarray([])
                self.y_ref = np.asarray([])
                self.timer = QTimer()
                self.timer.setInterval(self.period)
                self.timer.timeout.connect(self.update_plot)
                self.timer.start()
                print("Time (s) \t Voltage(v)")

    def update_plot(self):
        try:
            valor1 = self.a0.read()
            valor2 = self.a1.read()

            valor1 = (float(valor1)*(self.high_value_board))
            valor2 = (float(valor2)*(self.high_value_board))
            msg_console = "Tiempo:" + str(self.time_val / 1000.0)+" (s)"+"\t"
            msg_console += "Tension 1: " + "{0:.5f}".format(valor1)+" (V)\t"
            msg_console += "Tension 2: " + "{0:.5f}".format(valor2)+" (V)"
            print(msg_console)
            self.values.append(str(self.time_val/1000.0)+"," +
                               "{0:05f}".format(valor1)+"," +
                               "{0:05f}".format(valor2))

            self.canvas.axes.cla()
            self.x = np.append(self.x, self.time_val/1000.0)
            self.y1 = np.append(self.y1, valor1)
            self.y2 = np.append(self.y2, valor2)
            self.y_ref = np.append(self.y_ref, self.threshold / 1000)
            self.canvas.axes.set_xlabel("Time(s)")
            self.canvas.axes.set_ylabel("Voltage (V)")

            self.canvas.axes.plot(self.x, self.y1, 'C1o-')
            self.canvas.axes.plot(self.x, self.y2, 'C2o-')
            self.canvas.axes.plot(self.x, self.y_ref, 'C3o-')
            self.canvas.draw()

            if(valor1 > self.threshold/1000.0):
                self.d11.write(1)
            else:
                self.d11.write(0)
            if(valor2 > self.threshold/1000.0):
                self.d12.write(1)
            else:
                self.d12.write(0)
        except:
            pass

        self.count = self.count + 1
        self.time_val = self.time_val + self.period

        if (self.count > self.samples or self.stp_acq == True):
            self.timer.stop()
            self.count = 0
            self.stp_acq = False
            if(self.board != None):
                self.board.exit()
            self.btn_start.show()
            self.btn_save.show()
            self.btn_stop.hide()

    def spb_samples_changed(self, val_samples):
        self.samples = val_samples

    def spb_threshold_changed(self, val_umbral):
        self.threshold = val_umbral

    def add_port(self):
        self.com_port = str(self.cb_port.currentText())
        print("Serial port selected:", self.com_port)

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


if (__name__ == "__main__"):
    app = QApplication(sys.argv)
    window = MainWindow()
    window.show()
    app.exec_()

# -*- coding: utf-8 -*-
import wx
import winreg
import itertools
import matplotlib.pyplot as plt
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigureCanvas
#from matplotlib.figure import Figure
import matplotlib as plt
import numpy as np
# Scan ports
import serial
# Connection to Arduino
from pyfirmata import Arduino, util
import time
import glob
import sys


class TopPanel(wx.Panel):
    def __init__(self, parent):
        super().__init__(parent)
        self.figure = plt.figure.Figure()
        plt.style.use('ggplot')
        self.axes = self.figure.add_subplot(111)
        self.canvas = FigureCanvas(self, -1, self.figure)
        self.sizer = wx.BoxSizer(wx.HORIZONTAL)
        self.sizer.Add(self.canvas, 1, wx.EXPAND)
        self.SetSizer(self.sizer)
        self.axes.set_xlabel("Time (s)")
        self.axes.set_ylabel("Voltage (V)")
        self.axes.set_ylim(-0.1, 5.1)
        self.canvas.draw()

    def draw(self, x, y1, y2):
        self.axes.clear()
        self.axes.set_ylabel("Voltage (V)")
        self.axes.set_xlabel("Time (s)")
        self.axes.plot(x, y1, 'C1o--')
        self.axes.plot(x, y2, 'C2o--')
        self.canvas.draw()


class BottomPanel(wx.Panel):
    def __init__(self, parent, top):
        super().__init__(parent)
        self.graph = top
        self.buttonStart = wx.Button(self, id=1, label="Start",
                                     pos=(400, 40))
        self.buttonStart.Bind(wx.EVT_BUTTON, self.OnStartClick)
        self.buttonStop = wx.Button(self, id=2, label="Stop",
                                    pos=(400, 40))
        self.buttonStop.Bind(wx.EVT_BUTTON, self.OnStopClick)
        self.timer = wx.Timer(self)
        self.Bind(wx.EVT_TIMER, self.TimeInterval, self.timer)
        # Ports selection
        self.labelPort = wx.StaticText(self, label="Serial Port",
                                       pos=(40, 20))
        self.commPorts = wx.ListBox(self, id=3, pos=(40, 40),
                                    choices=self.getSerialPorts(),
                                    style=0, name="Ports")
        # Sampling selection
        self.LabelSamples = wx.StaticText(self, label="Samples",
                                          pos=(140, 20))
        self.spinCtrlTime = wx.SpinCtrl(self, id=4, value="20",
                                        pos=(140, 40), min=1, max=1000,
                                        initial=1, name="wxSpinCtrlTime")
        # Threshold selection
        self.LabelUmbral = wx.StaticText(self, label="Threshold (0 - 5000 mV)",
                                         pos=(220, 20))
        self.spinCtrlUmbral = wx.SpinCtrl(self, id=5, value="2500",
                                          pos=(220, 40), min=0, max=5000,
                                          initial=1, name="wxSpinCtrlUmbral")

        self.buttonSaveData = wx.Button(self, id=6, label="Save", pos=(500, 40),
                                        name="ButtonSaveData")
        self.buttonSaveData.Bind(wx.EVT_BUTTON, self.OnStartSaving)
        self.buttonSaveData.Hide()
        self.buttonStop.Hide()
        self.n = 0
        self.serialConnection = False
        self.x = np.array([])
        self.y1 = np.array([])
        self.y2 = np.array([])
        self.time = 0
        self.values = []
        self.stopAcquisition = False
        self.board = None
        self.highValueBoard = 5.0
        self.boardResolution = 1023
        self.samplingTime = 500
        self.umbral = 0

    def OnStartSaving(self, event):
        fdlg = wx.FileDialog(self, "Input setting file path", "",
                             "", "CSV_files(*.csv)|*.*", wx.FD_SAVE)

        if (fdlg.ShowModal() == wx.ID_OK):
            self.savePath = fdlg.GetPath()+".csv"
            try:
                myFile = open(self.savePath, 'w')
                myFile.write("Time_(s),Voltage_(v)"+"\n")
                for i in range(len(self.values)):
                    myFile.write(self.values[i]+"\n")
                myFile.close()
            except:
                pass

    def TimeInterval(self, event):
        self.buttonStart.Hide()
        self.buttonSaveData.Hide()
        self.buttonStop.Show()
        if(self.serialConnection == True):
            samples = int(self.spinCtrlTime.GetValue())
            self.umbral = int(self.spinCtrlUmbral.GetValue())
            try:
                valor1 = self.a0.read()
                valor2 = self.a1.read()
                valor1 = (float(valor1)*(self.highValueBoard))
                valor2 = (float(valor2)*(self.highValueBoard))
                msg_console = "Tiempo:" + str(self.time)+" (s)"+"\t"
                msg_console += "Tension 1: " + \
                    "{0:.5f}".format(valor1)+" (V)\t"
                msg_console += "Tension 2: " + "{0:.5f}".format(valor2)+" (V)"
                print(msg_console)
                self.values.append(str(self.time)+"," +
                                   "{0:05f}".format(valor1)+"," +
                                   "{0:05f}".format(valor2))
                self.y1 = np.append(self.y1, valor1)
                self.y2 = np.append(self.y2, valor2)
                self.x = np.append(self.x, self.time)
                self.graph.draw(self.x, self.y1, self.y2)
                if(valor1 > self.umbral/1000.0):
                    self.d11.write(1)
                else:
                    self.d11.write(0)
                if(valor2 > self.umbral/1000.0):
                    self.d12.write(1)
                else:
                    self.d12.write(0)
            except:
                pass

            self.time = self.time + 0.5
            self.n = self.n + 1

            if(self.n > samples or self.stopAcquisition == True):
                self.buttonStop.Hide()
                self.buttonStart.Show()
                self.buttonSaveData.Show()
                self.timer.Stop()
                self.serialConnection = False
                self.board.exit()

    def OnStartClick(self, event):
        if(self.board != None):
            self.board.exit()
        self.buttonStart.Hide()
        self.buttonSaveData.Hide()
        self.buttonStop.Show()
        self.n = 0
        self.time = 0
        self.x = np.array([])
        self.y1 = np.array([])
        self.y2 = np.array([])

        takeData = False
        self.serialConnection = False
        self.values = []
        self.stopAcquisition = False
        portVal = self.commPorts.GetSelection()
        if (portVal == -1):
            takeData = False
            wx.CallLater(10, self.ShowMessagePort)
        else:
            portSelected = self.commPorts.GetString(portVal)
            takeData = True

        if(self.serialConnection == False and takeData == True):
            self.timer.Start(self.samplingTime)
            try:
                self.board = Arduino(portSelected)
                self.it = util.Iterator(self.board)
                self.it.start()
                self.a0 = self.board.get_pin('a:0:i')
                self.a1 = self.board.get_pin('a:1:i')
                self.d11 = self.board.get_pin('d:11:o')
                self.d12 = self.board.get_pin('d:12:o')
                self.serialConnection = True
            except:
                self.serialConnection = False
                wx.CallLater(50, self.ShowMessageError)

    def ShowMessageError(self):
        wx.MessageBox('Communication with the board failed', 'Communication Error',
                      wx.OK | wx.ICON_ERROR)

    def ShowMessagePort(self):
        wx.MessageBox('No COM Port Selected', 'Serial Communication',
                      wx.OK | wx.ICON_ERROR)

    def OnStopClick(self, event):
        self.buttonStop.Hide()
        self.buttonStart.Show()
        self.stopAcquisition = True
        print("Stop")

    def getSerialPorts(self) -> list:
        if (sys.platform.startswith('win')):
            ports = ["COM%s" % (i+1) for i in range(256)]
        elif(sys.platform.startswith('Linux') or
             sys.platform.startswith('cygwin')):
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


class Main(wx.Frame):
    def __init__(self):
        super().__init__(None, title="Tarea 2 | wxPython",
                         size=(650, 650))
        splitter = wx.SplitterWindow(self)
        top = TopPanel(splitter)
        bottom = BottomPanel(splitter, top)
        splitter.SplitHorizontally(top, bottom, sashPosition=-130)
        splitter.SetMinimumPaneSize(450)

    def OnClose(self, event):
        self.Destroy()


if __name__ == "__main__":
    app = wx.App(redirect=False)
    frame = Main()
    frame.Show()
    app.MainLoop()

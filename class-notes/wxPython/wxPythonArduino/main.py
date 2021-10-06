# -*- coding: utf-8 -*-
"""
Created on Fri Oct  1 17:10:09 2021

@author: petir
"""

import wx
import winreg
import itertools
import matplotlib.pyplot as plt
from matplotlib.backends.backend_wxagg import FigureCanvasWxAgg as FigureCanvas
from matplotlib.figure import Figure
import numpy as np
import serial
import time
import glob
import sys

class TopPanel(wx.Panel):
    def __init__(self, parent):
        super().__init__(parent)
        self.figure = Figure()
        self.axes = self.figure.add_subplot(111)
        self.canvas = FigureCanvas(self, -1, self.figure)
        self.sizer = wx.BoxSizer(wx.HORIZONTAL)
        self.sizer.Add(self.canvas, 1, wx.EXPAND)
        self.SetSizer(self.sizer)
        self.axes.set_xlabel("Time (s)")
        self.axes.set_ylabel("Voltage (V)")
        self.axes.set_ylim(-0.1, 5.1)
        self.canvas.draw()
        
class BottomPanel(wx.Panel):
    def __init__(self, parent, top):
        super().__init__(parent)
        self.graph = top
        self.buttonStart = wx.Button(self, id = 1, label = "Start", 
                                     pos=(400,40))
        self.buttonStart.Bind(wx.EVT_BUTTON, self.OnStartClick)
        self.buttonStop = wx.Button(self, id = 2, label = "Stop", 
                                    pos=(400,40))
        self.buttonStop.Bind(wx.EVT_BUTTON, self.OnStopClick)
        
        self.timer = wx.Timer(self)
        self.Bind(wx.EVT_TIMER, self.TimeInterval, self.timer)
        self.labelPort = wx.StaticText(self, label="Serial Port:", 
                                       pos=(40,20))
        self.commPorts = wx.ListBox(self, id=3, pos=(40,40), 
                                    choices=self.getSerialPorts(), 
                                    style=0, name="Ports")     
        self.LabelSamples = wx.StaticText(self, label="Samples:",
                                          pos=(190,20))
        self.spintCtrlTime =  wx.SpinCtrl(self, id=4, value="",
                                          pos=(190,40), min=1, max=1000,
                                          initial=10, name="wxSpinCtrlTime")
        self.buttonSaveData = wx.Button(self, id=5, label="Save", 
                                        pos=(500,40),
                                        name="ButtonSaveData")
        self.buttonSaveData.Bind(wx.EVT_BUTTON, self.OnStartSave)
        self.buttonSaveData.Hide()
        self.buttonStop.Hide()
        self.n = 0
        self.serialConnection = False
        self.x = np.array([])
        self.y = np.array([])
        self.time = 0
        self.values = []
        self.stopAcquisition = False
        self.serialArduino = None
        self.highValueBoard = 5.0
        self.boardResolution = 1023
        self.samplingTime = 0.5
        
        
    def OnStartSave(self, event):
        print("Save")
        
    def OnStartClick(self, event):
        if self.serialArduino != None:
            self.serialArduino.close()
        self.buttonStart.Hide()
        self.buttonStop.Show()
        self.buttonSaveData.Hide()
        self.n = 0
        self.time = 0
        self.x = np.array([])
        self.y = np.array([])
        takeData = False
        self.serialConnection = False
        self.values = []
        self.stopAcquisition = False
        portVal = self.commPorts.GetSelection()
 
        if portVal == -1:
            takeData = False
            wx.CallLater(10, self.ShowErrorMessagePort)
        else:
            portSelected = self.commPorts.GetString(portVal)
            takeData = True

        if self.serialConnection == False and takeData == True:
            self.timer.Start(self.samplingTime)
            try:
                self.serialArduino = serial.Serial(str(portSelected), 9600, timeout=1)
                time.sleep(1)
                self.serialArduino.reset_input_buffer()
                self.serialConnection = True
                print(self.serialArduino)
            except:
                self.serialConnection = False
                wx.CallLater(50, self.ShowErrorMessageConnection)
            
        
    def OnStopClick(self, event):
        print("Stop")
        
    def TimeInterval(self, event):
        self.buttonStop.Show()
        self.buttonStart.Hide()
        self.buttonSaveData.Hide()
        
        if self.serialConnection:
            samples = int(self.spintCtrlTime.GetValue())
            try:
                temp = str(self.serialArduino.readline().decode('cp437'))
                temp = temp.replace("\r\n", "")
                value = (float(temp) * 
                         self.highValueBoard / self.boardResolution)
                printConsole = "Time: " + str(self.time) + " (s)\t"
                printConsole += "Voltage: " + str(value) + " (V)"
                print(printConsole)
            except:
                pass
            
            self.time += 0.5
            self.n += 1
            
            if self.n >= samples or self.stopAcquisition:
                self.buttonStop.Hide()
                self.buttonStart.Show()
                self.buttonSaveData.Show()
                self.timer.Stop()
                self.serialConnection = False
                
    
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
    
    def ShowErrorMessagePort(self):
        wx.MessageBox('No serial port selected or available.', 
                      'Serial Communication', wx.OK | wx.ICON_ERROR)
        
        
    def ShowErrorMessageConnection(self):
        wx.MessageBox('Communication with board failed.', 
                      'Communication Error', wx.OK | wx.ICON_ERROR)
    
        
        
class Main(wx.Frame):
    def __init__(self):
        super().__init__(None, title = "SPM Arduino and wxPython", 
                         size = (650, 650))
        splitter = wx.SplitterWindow(self)
        top = TopPanel(splitter)
        bottom = BottomPanel(splitter, top)
        splitter.SplitHorizontally(top, bottom, sashPosition= -100)
        splitter.SetMinimumPaneSize(450)
        
    def OnClose(self, event):
        self.Destroy()
        
if __name__ == "__main__":
    app = wx.App(redirect = False)
    frame = Main()
    frame.Show()
    app.MainLoop()
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
        pass
    
class BottomPanel(wx.Panel):
    def __init__(self, parent, top):
        super().__init__(parent)
        pass
    
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
# -*- coding: utf-8 -*-
"""
Created on Wed Sep 29 15:13:23 2021

@author: petir
"""

import wx

class MyPanel(wx.Panel):
    def __init__(self, parent):
        super().__init__(parent)
        button = wx.Button(self, label="Press me", pos=(100, 100))
        button.Bind(wx.EVT_BUTTON, self.on_button_press)
        self.count = 0
        
        
    def on_button_press(self, event):
        self.count += 1
        print("Pressed! " + str(self.count) + " times")
        return
        
class MyFrame(wx.Frame):
    def __init__(self):
        super().__init__(None, title="Hello World")
        panel = MyPanel(self)
        self.Show()
        
if __name__ == "__main__":
    app = wx.App(redirect=False)
    frame = MyFrame()
    app.MainLoop()
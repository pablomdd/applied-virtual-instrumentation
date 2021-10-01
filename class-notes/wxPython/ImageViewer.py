# -*- coding: utf-8 -*-
"""
Created on Wed Sep 29 15:44:05 2021

@author: petir
"""

import wx

class ImagePanel(wx.Panel):
    def __init__(self, parent, image_size):
        super().__init__(parent)
        self.max_size = 500
        img = wx.Image(*image_size)
        self.image_ctrl = wx.StaticBitmap(self, bitmap = wx.Bitmap(img))
        
        browse_btn = wx.Button(self, label="Browse...")
        browse_btn.Bind(wx.EVT_BUTTON, self.on_browse)
        
        self.photo_txt = wx.TextCtrl(self, size = (200, -1))
        main_sizer = wx.BoxSizer(wx.VERTICAL)
        main_sizer.Add(self.image_ctrl, 0, wx.ALL, 5)
        hsizer = wx.BoxSizer(wx.HORIZONTAL)
        hsizer.Add(browse_btn, 0 , wx.ALL, 5)
        hsizer.Add(self.photo_txt, 0 , wx.ALL, 5)
        main_sizer.Add(hsizer, 0, wx.ALL, 5)
        self.SetSizer(main_sizer)
        main_sizer.Fit(parent)
        self.Layout()
    
    # TODO: Write button handler
    def on_browse(self, event):
        wildcard = "JPEG files (*.jpg)|*.jpg"
        with wx.FileDialog(None, 'Choose a file', 
                           wildcard = wildcard,
                           style = wx.FD_OPEN) as dialog:
            if dialog.ShowModal() == wx.ID_OK:
                self.photo_txt.SetValue(dialog.GetPath())
                self.load_image()
        return
    
    def load_image(self):
        filepath = self.photo_txt.GetValue()
        img = wx.Image(filepath, wx.BITMAP_TYPE_ANY)
        W = img.GetWidth()
        H = img.GetHeight()
        
        if W > H:
            NewH = self.max_size
            newW = self.max_size * (H/W)
        else:
            NewH = self.max_size
            newW = self.max_size * (W/H)
            
        img.Scale(int(newW), int(NewH))
        self.image_ctrl.SetBitmap(wx.Bitmap(img))
        self.Refresh()
    
class MainFrame(wx.Frame):
    def __init__(self):
        super().__init__(None, title="Image Viewer")
        panel = ImagePanel(self, image_size = (250, 250))
        self.Show()
        
if __name__ == '__main__':
    app = wx.App(redirect = False)
    frame = MainFrame()
    app.MainLoop()
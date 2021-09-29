# -*- coding: utf-8 -*-
"""
Created on Wed Sep 29 15:44:05 2021

@author: petir
"""

import wx

class ImagePanel(wx.Panel):
    def __init__(self, parent, image_size):
        super().__init__(parent)
        self.max_size = 750
        img = wx.Image(*image_size)
        self.image_ctrl = wx.StaticBitmap(self, bitmap = wx.Bitmap(img))
        
        browse_btn = wx.Button(self, label="Browse...")
        browse_btn.Bind(wx.EVT_BUTTON, self.on_browse)
        
        self.photo_txt = wx.TextCtrl(self, size = (200, -1))
    
    # TODO: Write button handler
    def on_browse(self, event):
        return
import wx

class MyFrame(wx.Frame):
    def __init__(self):
        wx.Frame.__init__(self, None, title = "Hello World")
        self.Show()
        
if __name__ == "__main__":
    app = wx.App(redirect=False)
    frame = MyFrame()
    app.MainLoop()
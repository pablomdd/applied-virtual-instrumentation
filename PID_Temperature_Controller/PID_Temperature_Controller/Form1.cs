using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace PID_Temperature_Controller
{
    public partial class PID_Controller : Form
    {
        SerialPort serialPort;
        int period;
        int setPoint;
        int tT;
        int ti = 1000; //Integral Time (s)
        double td = 0.7; // Derivative Time (s)
        double t;
        bool flagStop;
        double[] time;
        double[] temperature;
        double[] uPID;
        double[] tH;
        double[] tL;
        int baudRate = 19200;
 
        public PID_Controller()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            {
                CB_SerialPort.Text = port;
            }
            Btn_Save.Visible = false;
        }

        private bool initSerial()
        {
            bool value;
            try
            {
                serialPort = new SerialPort(CB_SerialPort.Text);
                serialPort.BaudRate = baudRate;
                serialPort.WriteTimeout = 100;
                value = true;
            }
            catch
            {
                value = false;
            }
            return value;
        }
    }
}

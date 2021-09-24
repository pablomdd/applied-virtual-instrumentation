using System;
using System.Windows.Forms;
using System.IO.Ports; // Serial Port
using System.Threading; // Async temporitzation
using System.IO; // File management

namespace ArduinoForm
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        int m = 0;
        bool stopAdquisition = false;
        string[] dataStr = new string[0];
        public Form1()
        {
            InitializeComponent();
        }


        private bool InitSerial()
        {
            bool result = false;
            try
            {
                serialPort = new SerialPort(CB_Port.Text);
                serialPort.BaudRate = 9600;
                serialPort.WriteTimeout = 100;
                result = true;
            }
            catch
            {
                MessageBox.Show("Conexion to board failed.");
            }
            return result;
        }

        private async System.Threading.Tasks.Task GetDelay(int ms)
        {
            await System.Threading.Tasks.Task.Delay(ms);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach(var port in ports)
            {
                CB_Port.Text = port;
            }
            btn_save.Enabled = false;
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            btn_save.Enabled = false;
            btn_stop.Enabled = true;
            bool statusPort = false;
            int samplePeriod = 500; //ms
            dataStr = new string[0];
            int samples = Convert.ToUInt16(NUD_Samples.Value);
            m = 0;
            stopAdquisition = false;

            statusPort = InitSerial();
            Plt_Data.Series.Clear();
            Plt_Data.Series.Add("xy");
        }
    }
}

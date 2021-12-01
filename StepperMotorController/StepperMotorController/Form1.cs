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

namespace StepperMotorController
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                CB_Port.Text = port;
            }
            RB_Clockwise.Checked = true;
        }

        private bool initSer()
        {
            bool result = false;

            try
            {
                serialPort.BaudRate = 9600;
                serialPort.WriteTimeout = 100;
                result = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                result = false;
            }
            return result;
        }

        private async System.Threading.Tasks.Task GetDelay(int ms)
        {
            await System.Threading.Tasks.Task.Delay(ms);
        }

        private async void Btn_Start_Click(object sender, EventArgs e)
        {
            Btn_Start.Visible = false;
            bool statusPort = false;
            statusPort = initSer();
            string parameters = "";
            if (RB_Clockwise.Checked == true)
            {
                parameters += "CWS,";
            } else
            {
                parameters += "CCW,";
            }
            int revolutions = Convert.ToInt32(NUD_Revolutions.Value);
            parameters += revolutions.ToString("D1") + ",";
            int angle = Convert.ToInt32(NUD_Angle.Value);
            parameters += angle.ToString("D1") + "\r\n";

            if (statusPort == true)
            {
                serialPort.Open();
                await GetDelay(500);
                serialPort.Write(parameters);
                Txt_Data.Text = Convert.ToString(parameters);
            }
            serialPort.DiscardOutBuffer();
            Thread.Sleep(7000);
            serialPort.Close();
            await GetDelay(500);
            Btn_Start.Visible = true;
        }
    }
}

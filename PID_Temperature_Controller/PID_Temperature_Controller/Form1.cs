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

        private async System.Threading.Tasks.Task GetDelay(int ms)
        {
            await System.Threading.Tasks.Task.Delay(ms);
        }

        private async void Btn_Start_Click(object sender, EventArgs e)
        {
            Btn_Start.Visible = false;
            Btn_Save.Visible = false;

            bool statusBoard = false;
            string tdsString = "";

            statusBoard = initSerial();
            await GetDelay(1000);
            period = Convert.ToInt32(NUD_Period.Value);
            setPoint = Convert.ToInt32(NUD_SetPoint.Value);
            tT = Convert.ToInt32(NUD_tT.Value);
            // Conversión tT (min) to seconds
            tT *= 60;
            // Max value is  99.999 od derivate time
            if(td < 10)
            {
                tdsString = td.ToString("F3");
                tdsString = "0" + tdsString;
            }
            else
            {
                tdsString = td.ToString("F3");
            }
            string parameterMessage = "";
            // 9999 is max period value
            parameterMessage += period.ToString("D4");
            // Max valuee of the set point 99 C
            parameterMessage += "," + setPoint.ToString("D2") + ",";
            parameterMessage += tT.ToString("D4") + "," + ti.ToString("D4");
            parameterMessage += "," + tdsString;
            Txt_Display_Values.Text = parameterMessage;

            bool continueSteps = false;
            
            if(statusBoard == true)
            {
                serialPort.Open();
                try
                {
                    for (int i = 0; i < 2; i++)
                    {
                        await GetDelay(1000);
                        serialPort.WriteLine(parameterMessage);
                        continueSteps = true;
                    }
                } 
                catch
                {
                    MessageBox.Show("Failed Communication");
                    continueSteps = false;
                }
            }
            if (continueSteps)
            {
                Plt_PID.Series.Clear();
                Plt_PID.Series.Add("Temperature");
                Plt_PID.Series["Temperature"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                Plt_PID.Series["Temperature"].BorderWidth = 3;
                Plt_PID.Series["Temperature"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                Plt_PID.Series["Temperature"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                Plt_PID.Series["Temperature"].MarkerSize = 9;
                Plt_PID.Series["Temperature"].MarkerColor = Color.OrangeRed;
            }
        }
    }
}

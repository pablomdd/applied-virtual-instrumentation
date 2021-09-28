using System;
using System.Windows.Forms;
using System.IO.Ports; // Serial Port
using System.Threading; // Async temporitzation
using System.IO; // File management
using System.Drawing;

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
            // int samplePeriod = 500; //ms
            double time = 0;
            int period = 500;
            dataStr = new string[0];
            int samples = Convert.ToUInt16(NUD_Samples.Value);
            m = 0;
            stopAdquisition = false;

            Plt_Data.Series.Clear();
            Plt_Data.Series.Add("xy");
            Plt_Data.Series["xy"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Plt_Data.Series["xy"].BorderWidth = 3;
            Plt_Data.Series["xy"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            Plt_Data.Series["xy"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            Plt_Data.Series["xy"].MarkerSize = 9;
            Plt_Data.Series["xy"].Color = Color.OrangeRed;

            statusPort = InitSerial();
            await GetDelay(2000);
            if (statusPort)
            {
                serialPort.Open();
                serialPort.DiscardInBuffer();
                await GetDelay(1000);
                string data = "";
                double value = 0;
                int fail = 0;
                time = 0;
                for (int i = 0; i < samples; ++i)
                {
                    if(i == 0)
                    {
                        btn_stop.Enabled = true;
                    }
                    try
                    {
                        data = serialPort.ReadLine();
                        value = Convert.ToDouble(data) * (5.0 / 1023);
                        Plt_Data.Series["xy"].Points.AddXY(time, value);

                        Array.Resize(ref dataStr, dataStr.Length + 1);
                        dataStr[dataStr.Length - 1] = Convert.ToString(time) + "," + value.ToString("F4");

                        m++;
                    }
                    catch
                    {
                        fail++;
                    }
                    if (stopAdquisition)
                    {
                        break;
                    }
                    time = time + (period / 1000);
                    await GetDelay(period);

                }
                serialPort.Close();
            }
            await GetDelay(1000);
            btn_stop.Enabled = false;
            btn_start.Enabled = true;
            btn_save.Enabled = true;
        }

        private async void btn_stop_Click(object sender, EventArgs e)
        {
            stopAdquisition = true;
            btn_stop.Enabled = false;
            btn_start.Enabled = false;
            btn_save.Enabled = false;
            await GetDelay(1000);
            btn_start.Enabled = true;
            btn_save.Enabled = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            btn_save.Enabled = false;
            Stream myStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            if ( saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if((myStream = saveFileDialog.OpenFile()) != null)
                {
                    using(StreamWriter writer = new StreamWriter(myStream))
                    {
                        for (int i = 0; i < dataStr.Length; ++i)
                        {
                            writer.WriteLine(dataStr[i]);
                        }
                    }
                    myStream.Close();
                }
            }
            btn_start.Enabled = true;
            btn_save.Enabled = true;
        }
    }
}

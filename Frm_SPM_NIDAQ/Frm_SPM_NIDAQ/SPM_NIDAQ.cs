using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// TODO: Agregar las References a NationalInstruments .DAQmx y .Common 
// using NationalInstruments;
// using NationalInstruments.DAQmx;

namespace Frm_SPM_NIDAQ
{
    public partial class SPM_NIDAQ : Form
    {
        int samples;
        int period;
        double[] time;
        double[] voltageCh0;
        // NationalInstruments.DAQmx.Task analogTask;
        // AIChannel inputChannel0;
        // AnalogSingleChannelReader aIReader;

        bool stopAdquisition = false;

        public SPM_NIDAQ()
        {
            InitializeComponent();
        }
        // TODO: Agregar las References a National Instruments DAQmx y Common 
        private void SPM_NIDAQ_Load(object sender, EventArgs e)
        {
            Btn_Start.Visible = false;
            Btn_Save.Visible = false;
        }

        private bool DAQInit()
        {
            bool result = false;
            try
            {
                // analogInTask =  new NationalInstruments.DAQmx.Task();
                /*InputChannel0 = analogInTask.AIChannels.CreateVoltageChannel(
                    "dev1/ai0", 
                    "channel0", 
                    AITerminalConfiguration.Differential,
                    -10.0, 10.0, AIVoltageUnits.Volts);
            */
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The task wasn't created.");
                result = false;
            }
            return result;
        }
    
        private int GetSamples()
        {
            return Convert.ToInt32(NUD_Samples.Value);
        }

        private int GetPeriod()
        {
            return Convert.ToInt32(NUD_Period.Value);
        }

        private async System.Threading.Tasks.Task GetDelay(int ms)
        {
            await System.Threading.Tasks.Task.Delay(ms);
        }

        private async void Btn_Start_Click(object sender, EventArgs e)
        {
            Btn_Save.Visible = false;
            Btn_Start.Visible = false;
            Btn_Stop.Visible = true;

            bool takeData = false;
            stopAdquisition = false;

            takeData = DAQInit();

            if (takeData == true)
            {
                samples = GetSamples();
                period = GetPeriod();
                Plt_SPM.Series.Clear();
                Plt_SPM.Series.Add("VoltageCh0");
                Plt_SPM.Series["VoltageCh0"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                Plt_SPM.Series["VoltageCh0"].BorderWidth = 3;
                Plt_SPM.Series["VoltageCh0"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                Plt_SPM.Series["VoltageCh0"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;

                double t = 0;
                time = new double[0];
                voltageCh0 = new double[0];
                double tempVolt = 0;
                for (int i = 0; i < samples; i++)
                {
                    t = i * (period / 1000.0);
                    tempVolt = aIReader.ReadSingleSample();
                    Array.Resize(ref time, time.Length + 1);
                    time[time.Length - 1] = t;

                    Array.Resize(ref voltageCh0, voltageCh0.Length + 1);
                    voltageCh0[voltageCh0.Length - 1] = tempVolt;

                    Plt_SPM.Series["VoltageCh0"].Points.AddXY(t, tempVolt);
                    if (stopAdquisition == true)
                    {
                        break;
                    }
                    await GetDelay(period);
                }
                Btn_Save.Visible = true;
                Btn_Stop.Visible = false;
                Btn_Start.Visible = true;
            }
        }

        private async void Btn_Stop_Click(object sender, EventArgs e)
        {
            stopAdquisition = true;
            Btn_Start.Visible = false;
            Btn_Save.Visible = false;
            Btn_Stop.Visible = false;
            await GetDelay(2000);
            Btn_Start.Visible = true;
            Btn_Save.Visible = true;
        }
    }
}

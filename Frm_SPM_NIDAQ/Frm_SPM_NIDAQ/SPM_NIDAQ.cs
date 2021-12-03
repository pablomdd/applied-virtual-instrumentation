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
    }
}

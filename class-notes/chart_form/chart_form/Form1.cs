using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Manipular archivos
using System.IO;

namespace chart_form
{
    public partial class Form1 : Form
    {
        // Varibles de instancia
        int rows;
        int columns;
        double[,] data;
        public Form1()
        {
            InitializeComponent();
        }

        private void PopulateData(int rows, int columns, string[] lines)
        {
            string[] temp = new string[columns];
            data = new double[rows, columns];

            for(int i = 0; i < rows; i++)
            {
                temp = lines[i].Split(',', '\t');
                for (int j = 0; j < columns; j++)
                {
                    data[i, j] = Convert.ToDouble(temp[j]);
                }
            }
        }

        private double[,] Transposed(int rows, int columns)
        {
            double[,] transposed;
            transposed = new double[columns, rows];
            for(int i = 0; i < columns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    transposed[i, j] = data[j, i];
                }
            }
            return transposed;
        }

        private void Plot(int row, int col)
        {
            double[,] transposed = Transposed(row, col);
            string seriesNum;
            double x;
            double y;
            for(int i = 1; i < col; i++)
            {
                seriesNum = "Series" + Convert.ToString(i);
                Plt_Chart.Series.Add(seriesNum);
                Plt_Chart.Series[seriesNum].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                for (int j = 0; j < row; j++)
                {
                    x = transposed[0, j];
                    y = transposed[i, j];
                    Plt_Chart.Series[seriesNum].Points.AddXY(x, y);
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_ReadPlotData_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btn evento");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string line;
                string[] saveLine = new string[0];
                string[] temp;
                Txt_DisplayData.Text = "";
                System.IO.Stream fileStream = openFileDialog.OpenFile();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    while((line = reader.ReadLine()) != null)
                    {
                        Array.Resize(ref saveLine, saveLine.Length + 1);
                        saveLine[saveLine.Length - 1] = line;
                    }
                }
                fileStream.Close();
                for(int i = 0; i < saveLine.Length; i++)
                {
                    Txt_DisplayData.Text += saveLine[i] + "\r\n";
                }
                temp = saveLine[0].Split(',', '\t');
                columns = temp.Length;
                rows = saveLine.Length;
                PopulateData(rows, columns, saveLine);
                Plt_Chart.Series.Clear();
                Plot(rows, columns);
            }
        }
    }
}

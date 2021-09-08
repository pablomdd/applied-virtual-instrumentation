
namespace chart_form
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Plt_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Btn_ReadPlotData = new System.Windows.Forms.Button();
            this.Txt_DisplayData = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Plt_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Plt_Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.Plt_Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Plt_Chart.Legends.Add(legend1);
            this.Plt_Chart.Location = new System.Drawing.Point(319, 110);
            this.Plt_Chart.Name = "Plt_Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Plt_Chart.Series.Add(series1);
            this.Plt_Chart.Size = new System.Drawing.Size(458, 341);
            this.Plt_Chart.TabIndex = 0;
            this.Plt_Chart.Text = "chart1";
            this.Plt_Chart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Btn_ReadPlotData
            // 
            this.Btn_ReadPlotData.Location = new System.Drawing.Point(62, 110);
            this.Btn_ReadPlotData.Name = "Btn_ReadPlotData";
            this.Btn_ReadPlotData.Size = new System.Drawing.Size(166, 61);
            this.Btn_ReadPlotData.TabIndex = 1;
            this.Btn_ReadPlotData.Text = "Leer Y Graficar Data";
            this.Btn_ReadPlotData.UseVisualStyleBackColor = true;
            this.Btn_ReadPlotData.Click += new System.EventHandler(this.Btn_ReadPlotData_Click);
            // 
            // Txt_DisplayData
            // 
            this.Txt_DisplayData.Location = new System.Drawing.Point(62, 188);
            this.Txt_DisplayData.Multiline = true;
            this.Txt_DisplayData.Name = "Txt_DisplayData";
            this.Txt_DisplayData.ReadOnly = true;
            this.Txt_DisplayData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Txt_DisplayData.Size = new System.Drawing.Size(166, 263);
            this.Txt_DisplayData.TabIndex = 1;
            this.Txt_DisplayData.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 573);
            this.Controls.Add(this.Txt_DisplayData);
            this.Controls.Add(this.Btn_ReadPlotData);
            this.Controls.Add(this.Plt_Chart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Plt_Chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Plt_Chart;
        private System.Windows.Forms.Button Btn_ReadPlotData;
        private System.Windows.Forms.TextBox Txt_DisplayData;
    }
}


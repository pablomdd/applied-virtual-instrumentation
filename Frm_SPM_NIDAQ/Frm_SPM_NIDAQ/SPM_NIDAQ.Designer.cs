
namespace Frm_SPM_NIDAQ
{
    partial class SPM_NIDAQ
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Plt_SPM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NUD_Samples = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Samples = new System.Windows.Forms.Label();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Lbl_Period = new System.Windows.Forms.Label();
            this.NUD_Period = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Plt_SPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Samples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Period)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(71, 203);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(120, 44);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            // 
            // Plt_SPM
            // 
            chartArea2.Name = "ChartArea1";
            this.Plt_SPM.ChartAreas.Add(chartArea2);
            this.Plt_SPM.Location = new System.Drawing.Point(343, 39);
            this.Plt_SPM.Name = "Plt_SPM";
            this.Plt_SPM.Size = new System.Drawing.Size(366, 302);
            this.Plt_SPM.TabIndex = 1;
            this.Plt_SPM.Text = "chart1";
            // 
            // NUD_Samples
            // 
            this.NUD_Samples.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_Samples.Location = new System.Drawing.Point(71, 70);
            this.NUD_Samples.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_Samples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Samples.Name = "NUD_Samples";
            this.NUD_Samples.Size = new System.Drawing.Size(120, 27);
            this.NUD_Samples.TabIndex = 2;
            this.NUD_Samples.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_Samples.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Lbl_Samples
            // 
            this.Lbl_Samples.AutoSize = true;
            this.Lbl_Samples.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Samples.Location = new System.Drawing.Point(68, 39);
            this.Lbl_Samples.Name = "Lbl_Samples";
            this.Lbl_Samples.Size = new System.Drawing.Size(74, 20);
            this.Lbl_Samples.TabIndex = 3;
            this.Lbl_Samples.Text = "Samples";
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Location = new System.Drawing.Point(197, 203);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(120, 44);
            this.Btn_Stop.TabIndex = 6;
            this.Btn_Stop.Text = "Stop";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(71, 264);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(120, 44);
            this.Btn_Save.TabIndex = 7;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            // 
            // Lbl_Period
            // 
            this.Lbl_Period.AutoSize = true;
            this.Lbl_Period.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Period.Location = new System.Drawing.Point(68, 121);
            this.Lbl_Period.Name = "Lbl_Period";
            this.Lbl_Period.Size = new System.Drawing.Size(97, 20);
            this.Lbl_Period.TabIndex = 9;
            this.Lbl_Period.Text = "Period (ms)";
            // 
            // NUD_Period
            // 
            this.NUD_Period.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_Period.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_Period.Location = new System.Drawing.Point(71, 152);
            this.NUD_Period.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_Period.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_Period.Name = "NUD_Period";
            this.NUD_Period.Size = new System.Drawing.Size(120, 27);
            this.NUD_Period.TabIndex = 8;
            this.NUD_Period.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_Period.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // SPM_NIDAQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 439);
            this.Controls.Add(this.Lbl_Period);
            this.Controls.Add(this.NUD_Period);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.Lbl_Samples);
            this.Controls.Add(this.NUD_Samples);
            this.Controls.Add(this.Plt_SPM);
            this.Controls.Add(this.Btn_Start);
            this.Name = "SPM_NIDAQ";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SPM_NIDAQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Plt_SPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Samples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Period)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.DataVisualization.Charting.Chart Plt_SPM;
        private System.Windows.Forms.NumericUpDown NUD_Samples;
        private System.Windows.Forms.Label Lbl_Samples;
        private System.Windows.Forms.Button Btn_Stop;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Label Lbl_Period;
        private System.Windows.Forms.NumericUpDown NUD_Period;
    }
}


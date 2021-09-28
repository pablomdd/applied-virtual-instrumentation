
namespace ArduinoForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.Plt_Data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_start = new System.Windows.Forms.Button();
            this.CB_Port = new System.Windows.Forms.ComboBox();
            this.NUD_Samples = new System.Windows.Forms.NumericUpDown();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.Lbl_Samples = new System.Windows.Forms.Label();
            this.Lbl_Port = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Plt_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Samples)).BeginInit();
            this.SuspendLayout();
            // 
            // Plt_Data
            // 
            chartArea2.Name = "ChartArea1";
            this.Plt_Data.ChartAreas.Add(chartArea2);
            this.Plt_Data.Location = new System.Drawing.Point(191, 68);
            this.Plt_Data.Name = "Plt_Data";
            this.Plt_Data.Size = new System.Drawing.Size(547, 297);
            this.Plt_Data.TabIndex = 0;
            this.Plt_Data.Text = "chart1";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(45, 230);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(120, 40);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // CB_Port
            // 
            this.CB_Port.FormattingEnabled = true;
            this.CB_Port.Location = new System.Drawing.Point(44, 107);
            this.CB_Port.Name = "CB_Port";
            this.CB_Port.Size = new System.Drawing.Size(121, 24);
            this.CB_Port.TabIndex = 2;
            // 
            // NUD_Samples
            // 
            this.NUD_Samples.Location = new System.Drawing.Point(45, 181);
            this.NUD_Samples.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Samples.Name = "NUD_Samples";
            this.NUD_Samples.Size = new System.Drawing.Size(120, 22);
            this.NUD_Samples.TabIndex = 3;
            this.NUD_Samples.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_Samples.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(45, 276);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(120, 44);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(45, 326);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(120, 39);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Lbl_Samples
            // 
            this.Lbl_Samples.AutoSize = true;
            this.Lbl_Samples.Location = new System.Drawing.Point(42, 152);
            this.Lbl_Samples.Name = "Lbl_Samples";
            this.Lbl_Samples.Size = new System.Drawing.Size(66, 17);
            this.Lbl_Samples.TabIndex = 6;
            this.Lbl_Samples.Text = "Samples:";
            // 
            // Lbl_Port
            // 
            this.Lbl_Port.AutoSize = true;
            this.Lbl_Port.Location = new System.Drawing.Point(42, 68);
            this.Lbl_Port.Name = "Lbl_Port";
            this.Lbl_Port.Size = new System.Drawing.Size(38, 17);
            this.Lbl_Port.TabIndex = 7;
            this.Lbl_Port.Text = "Port:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lbl_Port);
            this.Controls.Add(this.Lbl_Samples);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.NUD_Samples);
            this.Controls.Add(this.CB_Port);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.Plt_Data);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Plt_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Samples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Plt_Data;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ComboBox CB_Port;
        private System.Windows.Forms.NumericUpDown NUD_Samples;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label Lbl_Samples;
        private System.Windows.Forms.Label Lbl_Port;
    }
}


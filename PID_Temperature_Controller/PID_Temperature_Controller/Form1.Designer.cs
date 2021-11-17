
namespace PID_Temperature_Controller
{
    partial class PID_Controller
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Lbl_SetPoint = new System.Windows.Forms.Label();
            this.Lbl_Period = new System.Windows.Forms.Label();
            this.Lbl_tT = new System.Windows.Forms.Label();
            this.Lbl_SerialPort = new System.Windows.Forms.Label();
            this.Lbl_DerivativeTime = new System.Windows.Forms.Label();
            this.Lbl_RemainingTime = new System.Windows.Forms.Label();
            this.Lbl_HighTime = new System.Windows.Forms.Label();
            this.Lbl_UPID = new System.Windows.Forms.Label();
            this.Lbl_Temperature = new System.Windows.Forms.Label();
            this.Lbl_LowerTemperature = new System.Windows.Forms.Label();
            this.Lbl_IntegralTime = new System.Windows.Forms.Label();
            this.Lbl_UpperTemperature = new System.Windows.Forms.Label();
            this.NUD_SetPoint = new System.Windows.Forms.NumericUpDown();
            this.NUD_Period = new System.Windows.Forms.NumericUpDown();
            this.NUD_tT = new System.Windows.Forms.NumericUpDown();
            this.CB_SerialPort = new System.Windows.Forms.ComboBox();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.Plt_PID = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Txt_Temperature = new System.Windows.Forms.TextBox();
            this.Txt_Display_Values = new System.Windows.Forms.TextBox();
            this.Txt_DerivativeTime = new System.Windows.Forms.TextBox();
            this.Txt_IntegralTime = new System.Windows.Forms.TextBox();
            this.Txt_UpperTemperature = new System.Windows.Forms.TextBox();
            this.Txt_RemainingTime = new System.Windows.Forms.TextBox();
            this.Txt_HighTime = new System.Windows.Forms.TextBox();
            this.Txt_LowerTemperature = new System.Windows.Forms.TextBox();
            this.Txt_UPID = new System.Windows.Forms.TextBox();
            this.Txt_UMax = new System.Windows.Forms.TextBox();
            this.Lbl_UMax = new System.Windows.Forms.Label();
            this.Btn_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Period)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_tT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plt_PID)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_SetPoint
            // 
            this.Lbl_SetPoint.AutoSize = true;
            this.Lbl_SetPoint.Location = new System.Drawing.Point(43, 44);
            this.Lbl_SetPoint.Name = "Lbl_SetPoint";
            this.Lbl_SetPoint.Size = new System.Drawing.Size(89, 17);
            this.Lbl_SetPoint.TabIndex = 0;
            this.Lbl_SetPoint.Text = "Set-Point (C)";
            // 
            // Lbl_Period
            // 
            this.Lbl_Period.AutoSize = true;
            this.Lbl_Period.Location = new System.Drawing.Point(52, 114);
            this.Lbl_Period.Name = "Lbl_Period";
            this.Lbl_Period.Size = new System.Drawing.Size(81, 17);
            this.Lbl_Period.TabIndex = 1;
            this.Lbl_Period.Text = "Period (ms)";
            this.Lbl_Period.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Lbl_tT
            // 
            this.Lbl_tT.AutoSize = true;
            this.Lbl_tT.Location = new System.Drawing.Point(22, 176);
            this.Lbl_tT.Name = "Lbl_tT";
            this.Lbl_tT.Size = new System.Drawing.Size(111, 17);
            this.Lbl_tT.TabIndex = 2;
            this.Lbl_tT.Text = "Total Time (min)";
            this.Lbl_tT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_SerialPort
            // 
            this.Lbl_SerialPort.AutoSize = true;
            this.Lbl_SerialPort.Location = new System.Drawing.Point(58, 233);
            this.Lbl_SerialPort.Name = "Lbl_SerialPort";
            this.Lbl_SerialPort.Size = new System.Drawing.Size(74, 17);
            this.Lbl_SerialPort.TabIndex = 3;
            this.Lbl_SerialPort.Text = "Serial Port";
            this.Lbl_SerialPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_DerivativeTime
            // 
            this.Lbl_DerivativeTime.AutoSize = true;
            this.Lbl_DerivativeTime.Location = new System.Drawing.Point(639, 211);
            this.Lbl_DerivativeTime.Name = "Lbl_DerivativeTime";
            this.Lbl_DerivativeTime.Size = new System.Drawing.Size(127, 17);
            this.Lbl_DerivativeTime.TabIndex = 5;
            this.Lbl_DerivativeTime.Text = "Derivative Time (s)";
            // 
            // Lbl_RemainingTime
            // 
            this.Lbl_RemainingTime.AutoSize = true;
            this.Lbl_RemainingTime.Enabled = false;
            this.Lbl_RemainingTime.Location = new System.Drawing.Point(639, 265);
            this.Lbl_RemainingTime.Name = "Lbl_RemainingTime";
            this.Lbl_RemainingTime.Size = new System.Drawing.Size(131, 17);
            this.Lbl_RemainingTime.TabIndex = 6;
            this.Lbl_RemainingTime.Text = "Remaining Time (s)";
            // 
            // Lbl_HighTime
            // 
            this.Lbl_HighTime.AutoSize = true;
            this.Lbl_HighTime.Location = new System.Drawing.Point(639, 315);
            this.Lbl_HighTime.Name = "Lbl_HighTime";
            this.Lbl_HighTime.Size = new System.Drawing.Size(104, 17);
            this.Lbl_HighTime.TabIndex = 7;
            this.Lbl_HighTime.Text = "High Time (ms)";
            // 
            // Lbl_UPID
            // 
            this.Lbl_UPID.AutoSize = true;
            this.Lbl_UPID.Location = new System.Drawing.Point(713, 366);
            this.Lbl_UPID.Name = "Lbl_UPID";
            this.Lbl_UPID.Size = new System.Drawing.Size(30, 17);
            this.Lbl_UPID.TabIndex = 8;
            this.Lbl_UPID.Text = "u(t)";
            // 
            // Lbl_Temperature
            // 
            this.Lbl_Temperature.AutoSize = true;
            this.Lbl_Temperature.Location = new System.Drawing.Point(639, 24);
            this.Lbl_Temperature.Name = "Lbl_Temperature";
            this.Lbl_Temperature.Size = new System.Drawing.Size(90, 17);
            this.Lbl_Temperature.TabIndex = 9;
            this.Lbl_Temperature.Text = "Temperature";
            // 
            // Lbl_LowerTemperature
            // 
            this.Lbl_LowerTemperature.AutoSize = true;
            this.Lbl_LowerTemperature.Location = new System.Drawing.Point(639, 73);
            this.Lbl_LowerTemperature.Name = "Lbl_LowerTemperature";
            this.Lbl_LowerTemperature.Size = new System.Drawing.Size(155, 17);
            this.Lbl_LowerTemperature.TabIndex = 10;
            this.Lbl_LowerTemperature.Text = "Lower Temperature (C)";
            // 
            // Lbl_IntegralTime
            // 
            this.Lbl_IntegralTime.AutoSize = true;
            this.Lbl_IntegralTime.Location = new System.Drawing.Point(639, 165);
            this.Lbl_IntegralTime.Name = "Lbl_IntegralTime";
            this.Lbl_IntegralTime.Size = new System.Drawing.Size(111, 17);
            this.Lbl_IntegralTime.TabIndex = 11;
            this.Lbl_IntegralTime.Text = "Integral Time (s)";
            // 
            // Lbl_UpperTemperature
            // 
            this.Lbl_UpperTemperature.AutoSize = true;
            this.Lbl_UpperTemperature.Location = new System.Drawing.Point(639, 118);
            this.Lbl_UpperTemperature.Name = "Lbl_UpperTemperature";
            this.Lbl_UpperTemperature.Size = new System.Drawing.Size(156, 17);
            this.Lbl_UpperTemperature.TabIndex = 12;
            this.Lbl_UpperTemperature.Text = "Upper Temperature (C)";
            // 
            // NUD_SetPoint
            // 
            this.NUD_SetPoint.Location = new System.Drawing.Point(12, 71);
            this.NUD_SetPoint.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NUD_SetPoint.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUD_SetPoint.Name = "NUD_SetPoint";
            this.NUD_SetPoint.Size = new System.Drawing.Size(120, 22);
            this.NUD_SetPoint.TabIndex = 13;
            this.NUD_SetPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_SetPoint.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // NUD_Period
            // 
            this.NUD_Period.Location = new System.Drawing.Point(13, 134);
            this.NUD_Period.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_Period.Minimum = new decimal(new int[] {
            833,
            0,
            0,
            0});
            this.NUD_Period.Name = "NUD_Period";
            this.NUD_Period.Size = new System.Drawing.Size(120, 22);
            this.NUD_Period.TabIndex = 14;
            this.NUD_Period.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_Period.Value = new decimal(new int[] {
            833,
            0,
            0,
            0});
            // 
            // NUD_tT
            // 
            this.NUD_tT.Location = new System.Drawing.Point(13, 196);
            this.NUD_tT.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NUD_tT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_tT.Name = "NUD_tT";
            this.NUD_tT.Size = new System.Drawing.Size(120, 22);
            this.NUD_tT.TabIndex = 15;
            this.NUD_tT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_tT.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CB_SerialPort
            // 
            this.CB_SerialPort.FormattingEnabled = true;
            this.CB_SerialPort.Location = new System.Drawing.Point(12, 258);
            this.CB_SerialPort.Name = "CB_SerialPort";
            this.CB_SerialPort.Size = new System.Drawing.Size(121, 24);
            this.CB_SerialPort.TabIndex = 16;
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(18, 315);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(115, 35);
            this.Btn_Start.TabIndex = 17;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Location = new System.Drawing.Point(17, 409);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(115, 35);
            this.Btn_Exit.TabIndex = 18;
            this.Btn_Exit.Text = "Exit";
            this.Btn_Exit.UseVisualStyleBackColor = true;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Plt_PID
            // 
            chartArea2.Name = "ChartArea1";
            this.Plt_PID.ChartAreas.Add(chartArea2);
            this.Plt_PID.Location = new System.Drawing.Point(172, 24);
            this.Plt_PID.Name = "Plt_PID";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.Plt_PID.Series.Add(series2);
            this.Plt_PID.Size = new System.Drawing.Size(431, 288);
            this.Plt_PID.TabIndex = 20;
            this.Plt_PID.Text = "chart1";
            // 
            // Txt_Temperature
            // 
            this.Txt_Temperature.Location = new System.Drawing.Point(642, 44);
            this.Txt_Temperature.Name = "Txt_Temperature";
            this.Txt_Temperature.ReadOnly = true;
            this.Txt_Temperature.Size = new System.Drawing.Size(100, 22);
            this.Txt_Temperature.TabIndex = 21;
            this.Txt_Temperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_Display_Values
            // 
            this.Txt_Display_Values.Location = new System.Drawing.Point(172, 335);
            this.Txt_Display_Values.Name = "Txt_Display_Values";
            this.Txt_Display_Values.ReadOnly = true;
            this.Txt_Display_Values.Size = new System.Drawing.Size(431, 22);
            this.Txt_Display_Values.TabIndex = 22;
            // 
            // Txt_DerivativeTime
            // 
            this.Txt_DerivativeTime.Location = new System.Drawing.Point(642, 233);
            this.Txt_DerivativeTime.Name = "Txt_DerivativeTime";
            this.Txt_DerivativeTime.ReadOnly = true;
            this.Txt_DerivativeTime.Size = new System.Drawing.Size(100, 22);
            this.Txt_DerivativeTime.TabIndex = 23;
            this.Txt_DerivativeTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_IntegralTime
            // 
            this.Txt_IntegralTime.Location = new System.Drawing.Point(642, 186);
            this.Txt_IntegralTime.Name = "Txt_IntegralTime";
            this.Txt_IntegralTime.ReadOnly = true;
            this.Txt_IntegralTime.Size = new System.Drawing.Size(100, 22);
            this.Txt_IntegralTime.TabIndex = 24;
            this.Txt_IntegralTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_UpperTemperature
            // 
            this.Txt_UpperTemperature.Location = new System.Drawing.Point(642, 140);
            this.Txt_UpperTemperature.Name = "Txt_UpperTemperature";
            this.Txt_UpperTemperature.ReadOnly = true;
            this.Txt_UpperTemperature.Size = new System.Drawing.Size(100, 22);
            this.Txt_UpperTemperature.TabIndex = 28;
            this.Txt_UpperTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_RemainingTime
            // 
            this.Txt_RemainingTime.Location = new System.Drawing.Point(642, 285);
            this.Txt_RemainingTime.Name = "Txt_RemainingTime";
            this.Txt_RemainingTime.ReadOnly = true;
            this.Txt_RemainingTime.Size = new System.Drawing.Size(100, 22);
            this.Txt_RemainingTime.TabIndex = 27;
            this.Txt_RemainingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_HighTime
            // 
            this.Txt_HighTime.Location = new System.Drawing.Point(642, 335);
            this.Txt_HighTime.Name = "Txt_HighTime";
            this.Txt_HighTime.ReadOnly = true;
            this.Txt_HighTime.Size = new System.Drawing.Size(100, 22);
            this.Txt_HighTime.TabIndex = 26;
            this.Txt_HighTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_LowerTemperature
            // 
            this.Txt_LowerTemperature.Location = new System.Drawing.Point(642, 93);
            this.Txt_LowerTemperature.Name = "Txt_LowerTemperature";
            this.Txt_LowerTemperature.ReadOnly = true;
            this.Txt_LowerTemperature.Size = new System.Drawing.Size(100, 22);
            this.Txt_LowerTemperature.TabIndex = 25;
            this.Txt_LowerTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_UPID
            // 
            this.Txt_UPID.Location = new System.Drawing.Point(642, 386);
            this.Txt_UPID.Name = "Txt_UPID";
            this.Txt_UPID.ReadOnly = true;
            this.Txt_UPID.Size = new System.Drawing.Size(100, 22);
            this.Txt_UPID.TabIndex = 30;
            this.Txt_UPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_UMax
            // 
            this.Txt_UMax.Location = new System.Drawing.Point(642, 438);
            this.Txt_UMax.Name = "Txt_UMax";
            this.Txt_UMax.ReadOnly = true;
            this.Txt_UMax.Size = new System.Drawing.Size(100, 22);
            this.Txt_UMax.TabIndex = 29;
            this.Txt_UMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_UMax
            // 
            this.Lbl_UMax.AutoSize = true;
            this.Lbl_UMax.Location = new System.Drawing.Point(696, 418);
            this.Lbl_UMax.Name = "Lbl_UMax";
            this.Lbl_UMax.Size = new System.Drawing.Size(45, 17);
            this.Lbl_UMax.TabIndex = 31;
            this.Lbl_UMax.Text = "u máx";
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(17, 363);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(115, 35);
            this.Btn_Save.TabIndex = 32;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // PID_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 483);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Lbl_UMax);
            this.Controls.Add(this.Txt_UPID);
            this.Controls.Add(this.Txt_UMax);
            this.Controls.Add(this.Txt_UpperTemperature);
            this.Controls.Add(this.Txt_RemainingTime);
            this.Controls.Add(this.Txt_HighTime);
            this.Controls.Add(this.Txt_LowerTemperature);
            this.Controls.Add(this.Txt_IntegralTime);
            this.Controls.Add(this.Txt_DerivativeTime);
            this.Controls.Add(this.Txt_Display_Values);
            this.Controls.Add(this.Txt_Temperature);
            this.Controls.Add(this.Plt_PID);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.CB_SerialPort);
            this.Controls.Add(this.NUD_tT);
            this.Controls.Add(this.NUD_Period);
            this.Controls.Add(this.NUD_SetPoint);
            this.Controls.Add(this.Lbl_UpperTemperature);
            this.Controls.Add(this.Lbl_IntegralTime);
            this.Controls.Add(this.Lbl_LowerTemperature);
            this.Controls.Add(this.Lbl_Temperature);
            this.Controls.Add(this.Lbl_UPID);
            this.Controls.Add(this.Lbl_HighTime);
            this.Controls.Add(this.Lbl_RemainingTime);
            this.Controls.Add(this.Lbl_DerivativeTime);
            this.Controls.Add(this.Lbl_SerialPort);
            this.Controls.Add(this.Lbl_tT);
            this.Controls.Add(this.Lbl_Period);
            this.Controls.Add(this.Lbl_SetPoint);
            this.Name = "PID_Controller";
            this.Text = "PID Temperature Controller Arduino & NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SetPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Period)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_tT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Plt_PID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_SetPoint;
        private System.Windows.Forms.Label Lbl_Period;
        private System.Windows.Forms.Label Lbl_tT;
        private System.Windows.Forms.Label Lbl_SerialPort;
        private System.Windows.Forms.Label Lbl_DerivativeTime;
        private System.Windows.Forms.Label Lbl_RemainingTime;
        private System.Windows.Forms.Label Lbl_HighTime;
        private System.Windows.Forms.Label Lbl_UPID;
        private System.Windows.Forms.Label Lbl_Temperature;
        private System.Windows.Forms.Label Lbl_LowerTemperature;
        private System.Windows.Forms.Label Lbl_IntegralTime;
        private System.Windows.Forms.Label Lbl_UpperTemperature;
        private System.Windows.Forms.NumericUpDown NUD_SetPoint;
        private System.Windows.Forms.NumericUpDown NUD_Period;
        private System.Windows.Forms.NumericUpDown NUD_tT;
        private System.Windows.Forms.ComboBox CB_SerialPort;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.DataVisualization.Charting.Chart Plt_PID;
        private System.Windows.Forms.TextBox Txt_Temperature;
        private System.Windows.Forms.TextBox Txt_Display_Values;
        private System.Windows.Forms.TextBox Txt_DerivativeTime;
        private System.Windows.Forms.TextBox Txt_IntegralTime;
        private System.Windows.Forms.TextBox Txt_UpperTemperature;
        private System.Windows.Forms.TextBox Txt_RemainingTime;
        private System.Windows.Forms.TextBox Txt_HighTime;
        private System.Windows.Forms.TextBox Txt_LowerTemperature;
        private System.Windows.Forms.TextBox Txt_UPID;
        private System.Windows.Forms.TextBox Txt_UMax;
        private System.Windows.Forms.Label Lbl_UMax;
        private System.Windows.Forms.Button Btn_Save;
    }
}


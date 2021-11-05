
namespace PID_Temperature_Controller
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
            this.Lbl_SetPoint = new System.Windows.Forms.Label();
            this.Lbl_Period = new System.Windows.Forms.Label();
            this.Lbl_tT = new System.Windows.Forms.Label();
            this.Lbl_SerialPort = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.NUD_SetPoint = new System.Windows.Forms.NumericUpDown();
            this.NUD_Period = new System.Windows.Forms.NumericUpDown();
            this.NUD_tT = new System.Windows.Forms.NumericUpDown();
            this.CB_SerialPort = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SetPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Period)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_tT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(696, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(696, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(696, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(696, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(688, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 9;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(688, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(688, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(688, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "label13";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 35);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 369);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 35);
            this.button2.TabIndex = 18;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 406);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 35);
            this.button3.TabIndex = 19;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(172, 24);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(431, 288);
            this.chart1.TabIndex = 20;
            this.chart1.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(642, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 21;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(172, 386);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(416, 22);
            this.textBox2.TabIndex = 22;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(642, 233);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 23;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(642, 186);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 24;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(642, 140);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 28;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(642, 285);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 27;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(642, 335);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 26;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(642, 93);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 25;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(642, 386);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 30;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(642, 438);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(696, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 483);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CB_SerialPort);
            this.Controls.Add(this.NUD_tT);
            this.Controls.Add(this.NUD_Period);
            this.Controls.Add(this.NUD_SetPoint);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Lbl_SerialPort);
            this.Controls.Add(this.Lbl_tT);
            this.Controls.Add(this.Lbl_Period);
            this.Controls.Add(this.Lbl_SetPoint);
            this.Name = "Form1";
            this.Text = "PID Temperature Controller Arduino & NET";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_SetPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Period)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_tT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_SetPoint;
        private System.Windows.Forms.Label Lbl_Period;
        private System.Windows.Forms.Label Lbl_tT;
        private System.Windows.Forms.Label Lbl_SerialPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown NUD_SetPoint;
        private System.Windows.Forms.NumericUpDown NUD_Period;
        private System.Windows.Forms.NumericUpDown NUD_tT;
        private System.Windows.Forms.ComboBox CB_SerialPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label5;
    }
}


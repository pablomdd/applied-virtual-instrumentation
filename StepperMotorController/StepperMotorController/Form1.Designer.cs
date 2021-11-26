
namespace StepperMotorController
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
            this.Lvl_Revolutions = new System.Windows.Forms.Label();
            this.NUD_Revolutions = new System.Windows.Forms.NumericUpDown();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.CB_Port = new System.Windows.Forms.ComboBox();
            this.Pn_Direction = new System.Windows.Forms.Panel();
            this.RB_Clockwise = new System.Windows.Forms.RadioButton();
            this.Txt_Data = new System.Windows.Forms.TextBox();
            this.Lbl_Angle = new System.Windows.Forms.Label();
            this.NUD_Angle = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Port = new System.Windows.Forms.Label();
            this.Lbl_Direction = new System.Windows.Forms.Label();
            this.RB_CounterClockwise = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Revolutions)).BeginInit();
            this.Pn_Direction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Angle)).BeginInit();
            this.SuspendLayout();
            // 
            // Lvl_Revolutions
            // 
            this.Lvl_Revolutions.AutoSize = true;
            this.Lvl_Revolutions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lvl_Revolutions.Location = new System.Drawing.Point(46, 40);
            this.Lvl_Revolutions.Name = "Lvl_Revolutions";
            this.Lvl_Revolutions.Size = new System.Drawing.Size(108, 24);
            this.Lvl_Revolutions.TabIndex = 0;
            this.Lvl_Revolutions.Text = "Revolutions";
            // 
            // NUD_Revolutions
            // 
            this.NUD_Revolutions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_Revolutions.Location = new System.Drawing.Point(50, 81);
            this.NUD_Revolutions.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_Revolutions.Name = "NUD_Revolutions";
            this.NUD_Revolutions.Size = new System.Drawing.Size(120, 28);
            this.NUD_Revolutions.TabIndex = 1;
            this.NUD_Revolutions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Btn_Start
            // 
            this.Btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Start.Location = new System.Drawing.Point(245, 126);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(121, 65);
            this.Btn_Start.TabIndex = 2;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            // 
            // CB_Port
            // 
            this.CB_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Port.FormattingEnabled = true;
            this.CB_Port.Location = new System.Drawing.Point(245, 81);
            this.CB_Port.Name = "CB_Port";
            this.CB_Port.Size = new System.Drawing.Size(121, 30);
            this.CB_Port.TabIndex = 3;
            // 
            // Pn_Direction
            // 
            this.Pn_Direction.Controls.Add(this.RB_CounterClockwise);
            this.Pn_Direction.Controls.Add(this.Lbl_Direction);
            this.Pn_Direction.Controls.Add(this.RB_Clockwise);
            this.Pn_Direction.Location = new System.Drawing.Point(418, 44);
            this.Pn_Direction.Name = "Pn_Direction";
            this.Pn_Direction.Size = new System.Drawing.Size(200, 124);
            this.Pn_Direction.TabIndex = 4;
            // 
            // RB_Clockwise
            // 
            this.RB_Clockwise.AutoSize = true;
            this.RB_Clockwise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Clockwise.Location = new System.Drawing.Point(7, 27);
            this.RB_Clockwise.Name = "RB_Clockwise";
            this.RB_Clockwise.Size = new System.Drawing.Size(116, 28);
            this.RB_Clockwise.TabIndex = 0;
            this.RB_Clockwise.TabStop = true;
            this.RB_Clockwise.Text = "Clockwise";
            this.RB_Clockwise.UseVisualStyleBackColor = true;
            // 
            // Txt_Data
            // 
            this.Txt_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Data.Location = new System.Drawing.Point(418, 196);
            this.Txt_Data.Name = "Txt_Data";
            this.Txt_Data.ReadOnly = true;
            this.Txt_Data.Size = new System.Drawing.Size(200, 28);
            this.Txt_Data.TabIndex = 10;
            // 
            // Lbl_Angle
            // 
            this.Lbl_Angle.AutoSize = true;
            this.Lbl_Angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Angle.Location = new System.Drawing.Point(46, 125);
            this.Lbl_Angle.Name = "Lbl_Angle";
            this.Lbl_Angle.Size = new System.Drawing.Size(60, 24);
            this.Lbl_Angle.TabIndex = 11;
            this.Lbl_Angle.Text = "Angle";
            // 
            // NUD_Angle
            // 
            this.NUD_Angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUD_Angle.Location = new System.Drawing.Point(50, 163);
            this.NUD_Angle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NUD_Angle.Name = "NUD_Angle";
            this.NUD_Angle.Size = new System.Drawing.Size(120, 28);
            this.NUD_Angle.TabIndex = 12;
            this.NUD_Angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUD_Angle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Lbl_Port
            // 
            this.Lbl_Port.AutoSize = true;
            this.Lbl_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Port.Location = new System.Drawing.Point(241, 40);
            this.Lbl_Port.Name = "Lbl_Port";
            this.Lbl_Port.Size = new System.Drawing.Size(43, 24);
            this.Lbl_Port.TabIndex = 13;
            this.Lbl_Port.Text = "Port";
            // 
            // Lbl_Direction
            // 
            this.Lbl_Direction.AutoSize = true;
            this.Lbl_Direction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Direction.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Direction.Name = "Lbl_Direction";
            this.Lbl_Direction.Size = new System.Drawing.Size(84, 24);
            this.Lbl_Direction.TabIndex = 14;
            this.Lbl_Direction.Text = "Direction";
            // 
            // RB_CounterClockwise
            // 
            this.RB_CounterClockwise.AutoSize = true;
            this.RB_CounterClockwise.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_CounterClockwise.Location = new System.Drawing.Point(7, 61);
            this.RB_CounterClockwise.Name = "RB_CounterClockwise";
            this.RB_CounterClockwise.Size = new System.Drawing.Size(188, 28);
            this.RB_CounterClockwise.TabIndex = 15;
            this.RB_CounterClockwise.TabStop = true;
            this.RB_CounterClockwise.Text = "Counter Clockwise";
            this.RB_CounterClockwise.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Lbl_Port);
            this.Controls.Add(this.NUD_Angle);
            this.Controls.Add(this.Lbl_Angle);
            this.Controls.Add(this.Txt_Data);
            this.Controls.Add(this.Pn_Direction);
            this.Controls.Add(this.CB_Port);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.NUD_Revolutions);
            this.Controls.Add(this.Lvl_Revolutions);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Revolutions)).EndInit();
            this.Pn_Direction.ResumeLayout(false);
            this.Pn_Direction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Angle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lvl_Revolutions;
        private System.Windows.Forms.NumericUpDown NUD_Revolutions;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.ComboBox CB_Port;
        private System.Windows.Forms.Panel Pn_Direction;
        private System.Windows.Forms.RadioButton RB_Clockwise;
        private System.Windows.Forms.TextBox Txt_Data;
        private System.Windows.Forms.Label Lbl_Angle;
        private System.Windows.Forms.NumericUpDown NUD_Angle;
        private System.Windows.Forms.Label Lbl_Port;
        private System.Windows.Forms.Label Lbl_Direction;
        private System.Windows.Forms.RadioButton RB_CounterClockwise;
    }
}



namespace CANObserver
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_Flowcontrol = new System.Windows.Forms.ComboBox();
            this.cb_Stopbits = new System.Windows.Forms.ComboBox();
            this.cb_Paritybits = new System.Windows.Forms.ComboBox();
            this.cb_Databits = new System.Windows.Forms.ComboBox();
            this.cb_Baudrate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_SerialPort = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Open = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_Flowcontrol);
            this.groupBox1.Controls.Add(this.cb_Stopbits);
            this.groupBox1.Controls.Add(this.cb_Paritybits);
            this.groupBox1.Controls.Add(this.cb_Databits);
            this.groupBox1.Controls.Add(this.cb_Baudrate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(293, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 194);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Parameters";
            // 
            // cb_Flowcontrol
            // 
            this.cb_Flowcontrol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Flowcontrol.FormattingEnabled = true;
            this.cb_Flowcontrol.Items.AddRange(new object[] {
            "None",
            "Hardware"});
            this.cb_Flowcontrol.Location = new System.Drawing.Point(89, 160);
            this.cb_Flowcontrol.Name = "cb_Flowcontrol";
            this.cb_Flowcontrol.Size = new System.Drawing.Size(102, 23);
            this.cb_Flowcontrol.TabIndex = 9;
            // 
            // cb_Stopbits
            // 
            this.cb_Stopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Stopbits.FormattingEnabled = true;
            this.cb_Stopbits.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cb_Stopbits.Location = new System.Drawing.Point(89, 126);
            this.cb_Stopbits.Name = "cb_Stopbits";
            this.cb_Stopbits.Size = new System.Drawing.Size(102, 23);
            this.cb_Stopbits.TabIndex = 8;
            // 
            // cb_Paritybits
            // 
            this.cb_Paritybits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Paritybits.FormattingEnabled = true;
            this.cb_Paritybits.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd",
            "Mark",
            "Space"});
            this.cb_Paritybits.Location = new System.Drawing.Point(89, 93);
            this.cb_Paritybits.Name = "cb_Paritybits";
            this.cb_Paritybits.Size = new System.Drawing.Size(102, 23);
            this.cb_Paritybits.TabIndex = 7;
            // 
            // cb_Databits
            // 
            this.cb_Databits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Databits.Enabled = false;
            this.cb_Databits.FormattingEnabled = true;
            this.cb_Databits.Items.AddRange(new object[] {
            "8"});
            this.cb_Databits.Location = new System.Drawing.Point(89, 60);
            this.cb_Databits.Name = "cb_Databits";
            this.cb_Databits.Size = new System.Drawing.Size(102, 23);
            this.cb_Databits.TabIndex = 6;
            // 
            // cb_Baudrate
            // 
            this.cb_Baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Baudrate.FormattingEnabled = true;
            this.cb_Baudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800"});
            this.cb_Baudrate.Location = new System.Drawing.Point(89, 22);
            this.cb_Baudrate.Name = "cb_Baudrate";
            this.cb_Baudrate.Size = new System.Drawing.Size(102, 23);
            this.cb_Baudrate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Flow control:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stop bits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parity  bits:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data bits:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Baud rate:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_SerialPort);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 78);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Serial Port";
            // 
            // cb_SerialPort
            // 
            this.cb_SerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SerialPort.FormattingEnabled = true;
            this.cb_SerialPort.Location = new System.Drawing.Point(6, 30);
            this.cb_SerialPort.Name = "cb_SerialPort";
            this.cb_SerialPort.Size = new System.Drawing.Size(263, 23);
            this.cb_SerialPort.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 110);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CAN Frame";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(230, 82);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 23);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "E";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(230, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(42, 23);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "e";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(42, 23);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "T";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 23);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "t";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(144, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 15);
            this.label13.TabIndex = 7;
            this.label13.Text = "EXT_REMOTE:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "EXT_DATA:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "STD_REMOTE:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "STD_DATA:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(227, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Header";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(144, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Format";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(99, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Header";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Format";
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(300, 240);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(193, 23);
            this.btn_Open.TabIndex = 4;
            this.btn_Open.Text = "Open COM port";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(504, 286);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Flowcontrol;
        private System.Windows.Forms.ComboBox cb_Stopbits;
        private System.Windows.Forms.ComboBox cb_Paritybits;
        private System.Windows.Forms.ComboBox cb_Databits;
        private System.Windows.Forms.ComboBox cb_Baudrate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_SerialPort;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Open;
    }
}
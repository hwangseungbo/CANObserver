
namespace CANObserver
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_RxCount = new System.Windows.Forms.Label();
            this.lbl_TxCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbox_data8 = new System.Windows.Forms.TextBox();
            this.tbox_data7 = new System.Windows.Forms.TextBox();
            this.tbox_data6 = new System.Windows.Forms.TextBox();
            this.tbox_data5 = new System.Windows.Forms.TextBox();
            this.tbox_data4 = new System.Windows.Forms.TextBox();
            this.tbox_data3 = new System.Windows.Forms.TextBox();
            this.tbox_data2 = new System.Windows.Forms.TextBox();
            this.tbox_data1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tbox_ID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Sendformat = new System.Windows.Forms.ComboBox();
            this.Monitor = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.PGN = new System.Windows.Forms.ColumnHeader();
            this.SPN = new System.Windows.Forms.ColumnHeader();
            this.Description = new System.Windows.Forms.ColumnHeader();
            this.Size = new System.Windows.Forms.ColumnHeader();
            this.Start = new System.Windows.Forms.ColumnHeader();
            this.Resolution = new System.Windows.Forms.ColumnHeader();
            this.DataRange = new System.Windows.Forms.ColumnHeader();
            this.Type = new System.Windows.Forms.ColumnHeader();
            this.Value = new System.Windows.Forms.ColumnHeader();
            this.비고 = new System.Windows.Forms.ColumnHeader();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.Monitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(845, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.Black;
            this.listBox.ForeColor = System.Drawing.Color.SpringGreen;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(0, 133);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(821, 304);
            this.listBox.TabIndex = 1;
            this.listBox.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.Monitor);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(821, 471);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btn_Clear);
            this.tabPage1.Controls.Add(this.listBox);
            this.tabPage1.Controls.Add(this.btn_Save);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(813, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Active Mode";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(665, 104);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(145, 23);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(513, 104);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(145, 23);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_RxCount);
            this.groupBox2.Controls.Add(this.lbl_TxCount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(513, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 92);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Counter";
            // 
            // lbl_RxCount
            // 
            this.lbl_RxCount.AutoSize = true;
            this.lbl_RxCount.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_RxCount.Location = new System.Drawing.Point(242, 59);
            this.lbl_RxCount.Name = "lbl_RxCount";
            this.lbl_RxCount.Size = new System.Drawing.Size(17, 19);
            this.lbl_RxCount.TabIndex = 3;
            this.lbl_RxCount.Text = "0";
            // 
            // lbl_TxCount
            // 
            this.lbl_TxCount.AutoSize = true;
            this.lbl_TxCount.Font = new System.Drawing.Font("Bernard MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_TxCount.Location = new System.Drawing.Point(242, 31);
            this.lbl_TxCount.Name = "lbl_TxCount";
            this.lbl_TxCount.Size = new System.Drawing.Size(17, 19);
            this.lbl_TxCount.TabIndex = 2;
            this.lbl_TxCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rx Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tx Count";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbox_data8);
            this.groupBox1.Controls.Add(this.tbox_data7);
            this.groupBox1.Controls.Add(this.tbox_data6);
            this.groupBox1.Controls.Add(this.tbox_data5);
            this.groupBox1.Controls.Add(this.tbox_data4);
            this.groupBox1.Controls.Add(this.tbox_data3);
            this.groupBox1.Controls.Add(this.tbox_data2);
            this.groupBox1.Controls.Add(this.tbox_data1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.tbox_ID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btn_Send);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_Sendformat);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sender";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(355, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡDATA(Hex)ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ";
            // 
            // tbox_data8
            // 
            this.tbox_data8.Location = new System.Drawing.Point(335, 85);
            this.tbox_data8.Name = "tbox_data8";
            this.tbox_data8.Size = new System.Drawing.Size(41, 23);
            this.tbox_data8.TabIndex = 20;
            this.tbox_data8.Text = "F0";
            this.tbox_data8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbox_data7
            // 
            this.tbox_data7.Location = new System.Drawing.Point(288, 85);
            this.tbox_data7.Name = "tbox_data7";
            this.tbox_data7.Size = new System.Drawing.Size(41, 23);
            this.tbox_data7.TabIndex = 19;
            this.tbox_data7.Text = "DF";
            this.tbox_data7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbox_data6
            // 
            this.tbox_data6.Location = new System.Drawing.Point(241, 85);
            this.tbox_data6.Name = "tbox_data6";
            this.tbox_data6.Size = new System.Drawing.Size(41, 23);
            this.tbox_data6.TabIndex = 18;
            this.tbox_data6.Text = "BC";
            this.tbox_data6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbox_data5
            // 
            this.tbox_data5.Location = new System.Drawing.Point(194, 85);
            this.tbox_data5.Name = "tbox_data5";
            this.tbox_data5.Size = new System.Drawing.Size(41, 23);
            this.tbox_data5.TabIndex = 17;
            this.tbox_data5.Text = "9A";
            this.tbox_data5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbox_data4
            // 
            this.tbox_data4.Location = new System.Drawing.Point(147, 85);
            this.tbox_data4.Name = "tbox_data4";
            this.tbox_data4.Size = new System.Drawing.Size(41, 23);
            this.tbox_data4.TabIndex = 16;
            this.tbox_data4.Text = "78";
            this.tbox_data4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbox_data3
            // 
            this.tbox_data3.Location = new System.Drawing.Point(100, 85);
            this.tbox_data3.Name = "tbox_data3";
            this.tbox_data3.Size = new System.Drawing.Size(41, 23);
            this.tbox_data3.TabIndex = 15;
            this.tbox_data3.Text = "56";
            this.tbox_data3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbox_data2
            // 
            this.tbox_data2.Location = new System.Drawing.Point(53, 85);
            this.tbox_data2.Name = "tbox_data2";
            this.tbox_data2.Size = new System.Drawing.Size(41, 23);
            this.tbox_data2.TabIndex = 14;
            this.tbox_data2.Text = "34";
            this.tbox_data2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbox_data1
            // 
            this.tbox_data1.Location = new System.Drawing.Point(6, 85);
            this.tbox_data1.Name = "tbox_data1";
            this.tbox_data1.Size = new System.Drawing.Size(41, 23);
            this.tbox_data1.TabIndex = 13;
            this.tbox_data1.Text = "12";
            this.tbox_data1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(391, 38);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 23);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // tbox_ID
            // 
            this.tbox_ID.Location = new System.Drawing.Point(231, 37);
            this.tbox_ID.Name = "tbox_ID";
            this.tbox_ID.Size = new System.Drawing.Size(129, 23);
            this.tbox_ID.TabIndex = 5;
            this.tbox_ID.Text = "123";
            this.tbox_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(403, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "DLC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "ID(Hex)";
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(391, 85);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(101, 23);
            this.btn_Send.TabIndex = 2;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Format";
            // 
            // cb_Sendformat
            // 
            this.cb_Sendformat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Sendformat.FormattingEnabled = true;
            this.cb_Sendformat.Items.AddRange(new object[] {
            "STD DATA",
            "STD REMOTE",
            "EXT DATA",
            "EXT REMOTE"});
            this.cb_Sendformat.Location = new System.Drawing.Point(6, 37);
            this.cb_Sendformat.Name = "cb_Sendformat";
            this.cb_Sendformat.Size = new System.Drawing.Size(199, 23);
            this.cb_Sendformat.TabIndex = 0;
            // 
            // Monitor
            // 
            this.Monitor.BackColor = System.Drawing.SystemColors.Control;
            this.Monitor.Controls.Add(this.listView1);
            this.Monitor.Location = new System.Drawing.Point(4, 24);
            this.Monitor.Name = "Monitor";
            this.Monitor.Padding = new System.Windows.Forms.Padding(3);
            this.Monitor.Size = new System.Drawing.Size(813, 443);
            this.Monitor.TabIndex = 3;
            this.Monitor.Text = "Monitor";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PGN,
            this.SPN,
            this.Description,
            this.Size,
            this.Start,
            this.Resolution,
            this.DataRange,
            this.Type,
            this.Value,
            this.비고});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 21);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(813, 422);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // PGN
            // 
            this.PGN.Text = "PGN";
            this.PGN.Width = 50;
            // 
            // SPN
            // 
            this.SPN.Text = "SPN";
            this.SPN.Width = 45;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 225;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.Width = 35;
            // 
            // Start
            // 
            this.Start.Text = "Start";
            this.Start.Width = 40;
            // 
            // Resolution
            // 
            this.Resolution.Text = "Resolution";
            this.Resolution.Width = 170;
            // 
            // DataRange
            // 
            this.DataRange.Text = "DataRange";
            this.DataRange.Width = 90;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 65;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 100;
            // 
            // 비고
            // 
            this.비고.Text = "비고";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(23, 20);
            this.toolStripMenuItem1.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(845, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CANObserver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.Monitor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_RxCount;
        private System.Windows.Forms.Label lbl_TxCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.TabPage Monitor;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader PGN;
        private System.Windows.Forms.ColumnHeader SPN;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader Start;
        private System.Windows.Forms.ColumnHeader Resolution;
        private System.Windows.Forms.ColumnHeader DataRange;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ColumnHeader 비고;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cb_Sendformat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbox_data8;
        private System.Windows.Forms.TextBox tbox_data7;
        private System.Windows.Forms.TextBox tbox_data6;
        private System.Windows.Forms.TextBox tbox_data5;
        private System.Windows.Forms.TextBox tbox_data4;
        private System.Windows.Forms.TextBox tbox_data3;
        private System.Windows.Forms.TextBox tbox_data2;
        private System.Windows.Forms.TextBox tbox_data1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox tbox_ID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}


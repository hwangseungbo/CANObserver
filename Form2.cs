using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace CANObserver
{
    public partial class Form2 : Form
    {
        //실제 연결하는 시리얼 포트 선언
        public SerialPort _serialPort = new SerialPort();
        Form1 form1 = new Form1();
        string[] datas = new string[6];

        //델리게이트
        public delegate void DataPassEventHandler(string[] data);

        //이벤트 생성
        public event DataPassEventHandler DataPassEvent;

        public Form2()
        {
            InitializeComponent();
            cb_Baudrate.SelectedIndex = 6;
            cb_Databits.SelectedIndex = 0;
            cb_Paritybits.SelectedIndex = 0;
            cb_Stopbits.SelectedIndex = 0;
            cb_Flowcontrol.SelectedIndex = 0;


            string[] ports = SerialPort.GetPortNames();
            for (int index = 0; index < ports.Length; index++)
            {
                cb_SerialPort.Items.Add(ports[index]);
                cb_SerialPort.SelectedIndex = index;
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(520, 325);
            this.MaximizeBox = false;

            btn_Open.Focus();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            datas[0] = cb_SerialPort.Text;
            datas[1] = cb_Baudrate.Text;
            datas[2] = cb_Databits.Text;
            datas[3] = cb_Paritybits.SelectedIndex + "";
            datas[4] = cb_Stopbits.Text;
            datas[5] = cb_Flowcontrol.SelectedIndex + "";

            DataPassEvent(datas);

            this.Close();
        }


    }// public partial class Form2 End!!!
}

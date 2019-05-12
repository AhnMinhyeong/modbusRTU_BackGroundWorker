using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using EasyModbus;

namespace modbusRTU
{
    public partial class MainForm : Form
    {
        private EasyModbus.ModbusClient modbusClient;
        string receiveData = null;
        string sendData = null;
        delegate void UpdateReceiveDataCallback();

        public MainForm()
        {
            InitializeComponent();
            modbusClient = new EasyModbus.ModbusClient();
            modbusClient.ReceiveDataChanged += new EasyModbus.ModbusClient.ReceiveDataChangedHandler(UpdateReceiveData);
            modbusClient.SendDataChanged += new EasyModbus.ModbusClient.SendDataChangedHandler(UpdateSendData);
            modbusClient.ConnectedChanged += new EasyModbus.ModbusClient.ConnectedChangedHandler(UpdateConnectedChanged);
        }

        //UpdateReceiveData Parts Start
        void UpdateReceiveData(object sender)
        {
            textBox1.Clear();
            receiveData = "Rx : " + BitConverter.ToString(modbusClient.receiveData).Replace("-", " ") + System.Environment.NewLine;
            Thread thread = new Thread(updateReceiveTextBox);
            thread.Start();
        }

        void updateReceiveTextBox()
        {
            if(textBox1.InvokeRequired)
            {
                UpdateReceiveDataCallback d = new UpdateReceiveDataCallback(updateReceiveTextBox);
                this.Invoke(d, new object[] { });
            }
            else
            {
                textBox1.AppendText(receiveData);
            }
        }
        //UpdateReceiveData Parts End

        //UpdateSendData Parts start
        void UpdateSendData(Object sender)
        {
            sendData = "Tx : " + BitConverter.ToString(modbusClient.sendData).Replace("-", " ") + System.Environment.NewLine;
            Thread thread = new Thread(updateSendTextBox);
            thread.Start();
        }

        void updateSendTextBox()
        {
            if(textBox1.InvokeRequired)
            {
                UpdateReceiveDataCallback d = new UpdateReceiveDataCallback(updateSendTextBox);
                this.Invoke(d, new object[] { });
            }
            else
            {
                textBox1.AppendText(sendData);
            }
        }
        //UpdateSendData Parts End

        //UpdateConnectedChanged Parts Start
        private void UpdateConnectedChanged(object sender)
        {
            if(modbusClient.Connected)
            {
                txtConnectstatus.Text = "Connected to Server";
                txtConnectstatus.BackColor = Color.Green;
                connect.Text = "Disconnect!";
            }
            else
            {
                txtConnectstatus.Text = "Not Connected to Server";
                txtConnectstatus.BackColor = Color.Red;
                connect.Text = "Connect!";
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (modbusClient.Connected)
                {
                    modbusClient.Disconnect();
                }
                else
                {
                    modbusClient.SerialPort = "COM3";
                    modbusClient.Baudrate = 38400;
                    modbusClient.Parity = System.IO.Ports.Parity.None;
                    modbusClient.StopBits = System.IO.Ports.StopBits.One;
                    modbusClient.Connect();
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Unable to connect to Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FC1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modbusClient.Connected)
                {
                    MessageBox.Show("Not connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                modbusClient.ReadCoils(0, 1);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "No response from Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                modbusClient.Disconnect();
            }
        }
    }
}

using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TcpSend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient(textBox1.Text,int.Parse(textBox2.Text));
            NetworkStream ns = tcpClient.GetStream();
            FileStream fs = File.Open("Form1.cs", FileMode.Open);
            int data = fs.ReadByte();

            while (data != -1)
            {
                ns.WriteByte((byte)data);
                data = fs.ReadByte();
            }

            fs.Close();
            ns.Close();
            tcpClient.Close();
        }
    }
}

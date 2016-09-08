using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace TcpReceive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(Listen));
            thread.Start();
        }

        public void Listen()
        {
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, 
                ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 2112));
            listener.Listen(0);
            Socket socket = listener.Accept();
            Stream netStream = new NetworkStream(socket);
            StreamReader reader = new StreamReader(netStream);
            string result = reader.ReadToEnd();
            Invoke(new UpdateDisplayDelegate(UpdateDisplay), result);
            socket.Close();
            listener.Close();

            //用TcpListener类实现
            /*IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            Int32 port = 2112;
            TcpListener tcpListener = new TcpListener(localAddr,port);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            NetworkStream ns = tcpClient.GetStream();
            StreamReader sr = new StreamReader(ns);
            string result = sr.ReadToEnd();
            Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { result });
            tcpClient.Close();
            tcpListener.Stop();*/
        }

        public void UpdateDisplay(string text)
        {
            txtDisplay.Text = text;
        }

        protected delegate void UpdateDisplayDelegate(string text);
    }
}

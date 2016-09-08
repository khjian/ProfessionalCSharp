using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] receiveBytes = new byte[1024];
            IPHostEntry ipHost = Dns.GetHostEntry("127.0.0.1");
            IPAddress ipAddress = ipHost.AddressList[2];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress,2112);
            Console.WriteLine("Starting:Creating Socket object");

            Socket sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, 
                ProtocolType.Tcp);
            sender.Connect(ipEndPoint);
            Console.WriteLine($"Successfully connected to {sender.RemoteEndPoint}");
            string sendingMessage = "Hello world socket test";
            Console.WriteLine("Creating message:Hello World Socket Test");
            byte[] forwardMessage = Encoding.ASCII.GetBytes(sendingMessage
                                                            + "[FINAL]");
            sender.Send(forwardMessage);
            int totalBytesReceived = sender.Receive(receiveBytes);
            Console.WriteLine("Message provided from server:" +
                              $"{Encoding.ASCII.GetString(receiveBytes,0,totalBytesReceived)}");
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            Console.ReadLine();
        }
    }
}

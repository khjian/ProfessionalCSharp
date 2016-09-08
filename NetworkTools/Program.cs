using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTools
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry wroxHost = Dns.GetHostEntry("www.wrox.com");
            IPHostEntry wroxHostCopy = Dns.GetHostEntry("208.215.179.178");

            Console.ReadKey();
        }
    }
}

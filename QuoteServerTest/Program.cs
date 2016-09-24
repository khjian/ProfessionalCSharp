using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var qs = new QuoteServer("quotes.txt", 4567);
            qs.Start();
            Console.WriteLine("Hit return to exit");
            Console.ReadLine();
            qs.Stop();
        }
    }
}

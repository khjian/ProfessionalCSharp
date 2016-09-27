using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteService
{
    class Program
    {
        static void Main(string[] args)
        {
            var qs = new QuoteServer("quotes.txt", 7890);
            qs.Start();
            Console.WriteLine("Hit return to exit");
            Console.ReadLine();
            qs.Stop();
        }
    }
}

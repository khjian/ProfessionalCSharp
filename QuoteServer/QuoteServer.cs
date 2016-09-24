using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuoteServer
{
    public class QuoteServer
    {
        private TcpListener listener;
        private int port;
        private string filename;
        private List<string> quotes;
        private Random random;
        private Task listenerTask;

        public QuoteServer()
            :this("quotes.txt")
        {
        }

        public QuoteServer(string filename) 
            : this(filename, 7890)
        {
        }

        public QuoteServer(string filename, int port)
        {
            Contract.Requires<ArgumentNullException>(filename != null);
            Contract.Requires<ArgumentException>(port >= IPEndPoint.MinPort &&
                port <= IPEndPoint.MaxPort);
            this.filename = filename;
            this.port = port;
        }

        protected void ReadQuotes()
        {
            try
            {
                quotes = File.ReadAllLines(filename).ToList();
                if (quotes.Count == 0)
                {
                    throw new QuoteException("quote file is empty");
                }
                random = new Random();
            }
            catch (IOException ex)
            {
                throw new QuoteException("I/O Error",ex);
            }
        }

        protected string GetRandomQuoteOfTheDay()
        {
            var index = random.Next(0, quotes.Count);
            return quotes[index];
        }

        protected void Listener()
        {
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }

    public class QuoteException : Exception
    {
        public QuoteException(string quoteFileIsEmpty)
        {
            throw new NotImplementedException();
        }

        public QuoteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

using System;
using System.IO;

namespace Wrox.ProCSharp.Assemblies
{
    public class SharedDemo
    {
        private string[] quotes;
        private Random random;

        public SharedDemo(string filename)
        {
            quotes = File.ReadAllLines(filename);
            random = new Random();
        }

        public string GetQuoteOfTheDay()
        {
            int index = random.Next(1, quotes.Length);
            return quotes[index];
        }
    }
}

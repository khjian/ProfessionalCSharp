using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foundation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Greeting("song"));

            Console.ReadLine();
        }

        static string Greeting(string name)
        {
            Thread.Sleep(3000);
            return $"Hello,{name}";
        }

        static Task<string> GreetingAsync(string name)
        {
            return Task.Run(() => Greeting(name));
        }

        private static async void CallerWithAsync()
        {
            var result = await GreetingAsync("Stephanie");
            Console.WriteLine(result);
        }
        private static async void CallerWithAsync2()
        {
            Console.WriteLine(await GreetingAsync("Stephanie"));
        }

        private static void CallerWithContinuationTask()
        {
            Task<string> t1 = GreetingAsync("Stephanie");
            t1.ContinueWith(
                t =>
                {
                    string result = t.Result;
                    Console.WriteLine(result);
                }
                );
        }
    }
}

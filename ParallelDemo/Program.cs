using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(Go).Start("arg1");
            new Thread(delegate()
            {
                GoGoGo("arg1", "a2", "a3");
            });
            new Thread(() =>
            {
                GoGoGo("a1","a2","a3");
            }).Start();

            Console.ReadKey();
        }

        public static void Go(object o)
        {
            Console.WriteLine($"我是线程:{Thread.CurrentThread.ManagedThreadId}");
        }

        public static void GoGoGo(string arg1, string arg2, string arg3)
        {
            Console.WriteLine($"GoGoGo我是线程:{Thread.CurrentThread.ManagedThreadId}");
        }

        static void ParallelFor()
        {
            ParallelLoopResult result =
                Parallel.For(0, 10, i =>
                {
                    Console.WriteLine($"{i},task:{Task.CurrentId}," +
                                      $"thread:{Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(10);
                });
            Console.WriteLine($"Is completed:{result.IsCompleted}");
        }

        static void ParallelFor2()
        {
            ParallelLoopResult result =
                Parallel.For(0, 10, async i =>
                 {
                     Console.WriteLine($"{i},task:{Task.CurrentId}," +
                                       $"thread:{Thread.CurrentThread.ManagedThreadId}");
                     await Task.Delay(10);

                     Console.WriteLine($"{i},task:{Task.CurrentId}," +
                                       $"thread:{Thread.CurrentThread.ManagedThreadId}");
                 });
            Console.WriteLine($"Is completed:{result.IsCompleted}");
        }
    }
}

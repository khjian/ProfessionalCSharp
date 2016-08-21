using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            ParentAndChild();
            Console.ReadKey();
        }

        static void ParentAndChild()
        {
            var parent = new Task(ParentTask);
            parent.Start();
            Thread.Sleep(2000);
            Console.WriteLine(parent.Status);
            Thread.Sleep(4000);
            Console.WriteLine(parent.Status);
        }

        static void ParentTask()
        {
            Console.WriteLine($"task id {Task.CurrentId}");
            var child = new Task(ChildTask);
            child.Start();
            Thread.Sleep(1000);
            Console.WriteLine("parent started child");
        }

        static void ChildTask()
        {
            Console.WriteLine("child");
            Thread.Sleep(5000);
            Console.WriteLine("child finished");
        }

        static object taskMethoLock = new object();
        static void TaskMethod(object title)
        {
            lock (taskMethoLock)
            {
                Console.WriteLine(title);
            }
        }
    }
}

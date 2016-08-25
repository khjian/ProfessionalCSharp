using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var state1 = new StateObject();
            var state2 = new StateObject();
            new Task(new SampleTask(state1,state2).Deadlock1).Start();
            new Task(new SampleTask(state1, state2).Deadlock2).Start();
            Console.ReadKey();
        }

        static void ThreadMain()
        { }

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

        static object obj = new object();
        static void TaskMethod()
        {
            bool lockTaken = false;
            Monitor.TryEnter(obj, 500, ref lockTaken);
            if (lockTaken)
            {
                try
                {
                    //acquired the lock
                    //synchronized region for obj
                }
                finally
                {
                    Monitor.Exit(obj);
                }
            }
            else
            {
                //did't get the lock,do something else
            }
        }
    }

    
}

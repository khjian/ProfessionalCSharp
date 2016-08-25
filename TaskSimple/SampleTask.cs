using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSimple
{
    public class SampleTask
    {
        private StateObject s1, s2;
        public SampleTask(StateObject s1, StateObject s2)
        {
            this.s1 = s1;
            this.s2 = s2;
        }

        public void Deadlock1()
        {
            int i = 0;
            while (true)
            {
                lock (s1)
                {
                    lock (s2)
                    {
                        s1.ChangeState(i);
                        s2.ChangeState(i++);
                        Console.WriteLine($"still running,{i}");
                    }
                }
            }
        }

        public void Deadlock2()
        {
            int i = 0;
            while (true)
            {
                lock (s2)
                {
                    lock (s1)
                    {
                        s1.ChangeState(i);
                        s2.ChangeState(i++);
                        Console.WriteLine($"still running,{i}");
                    }
                }
            }
        }

        public void RaceCondition(object o)
        {
            Trace.Assert(o is object, "o must be of type StateObject");
            StateObject state = o as StateObject;

            int i = 0;
            while (true)
            {
                state.ChangeState(i++);
            }
        }
    }
}

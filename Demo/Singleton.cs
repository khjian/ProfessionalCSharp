using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public sealed class Singleton
    {
        private static Singleton myInstance;
        private static readonly object lockRoot = new object();
        private Singleton()
        { }

        public static Singleton GetInstance()
        {
            if (myInstance == null)
            {
                lock (lockRoot)
                {
                    if (myInstance == null)
                    {
                        myInstance = new Singleton();
                    }
                }
            }
            return myInstance;
        }
    }
}

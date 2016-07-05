using System;
using System.Windows;

namespace Demo.Delegates
{
    public class Consumer:IWeakEventListener
    {
        private readonly string name;

        public Consumer(string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender, CarInfoEventArgs e)
        {
            Console.WriteLine($"{name}: car {e.Car} is new");
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            NewCarIsHere(sender,e as CarInfoEventArgs);
            return true;
        }
    }
}
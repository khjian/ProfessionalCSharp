using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            BankCard bc = new BankCard(1,1,1);
            Wallet<>
            Console.ReadLine();
        }
    }
    
    #region Animal
    class Animal
    {
        public virtual void Eat()
        {
            Console.WriteLine("Animail eat");
        }
    }
    #endregion

    #region Cat
    class Cat : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Cat eat");
        }
    }
    #endregion
}

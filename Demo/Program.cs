using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{

    class Program
    {
       
        public static string StrAddTwo(string x)
        {
            return x + 2;
        }

        public static string StrAddThree(string x)
        {
            return x + 3;
        }

        public delegate string StrAdd(string x);

        static void Main(string[] args)
        {
            StrAdd strAdd = StrAddTwo;
            Console.WriteLine(strAdd("Test"));
            strAdd = StrAddThree;
            Console.WriteLine(strAdd("Test"));

            Console.ReadKey();
        }
    }
    
    #region Animal
    class Animal:IComparable<Animal>
    {
        public virtual void Eat()
        {
            Console.WriteLine("Animail eat");
        }

        public int CompareTo(Animal other)
        {
            return 1;
        }
    }
    #endregion

    #region Cat
    class Cat : Animal,IComparable<Cat>
    {
        public override void Eat()
        {
            Console.WriteLine("Cat eat");
        }

        public int CompareTo(Cat other)
        {
            return 1;
        }
    }
    #endregion

    #region 协变和逆变
    /*
      IEnumerable<Cat> lCats = new List<Cat>();
            IEnumerable<Animal> lAnimals = lCats;//协变

            IComparable<Cat> ICat2 = new Cat();
            IComparable<Animal> IAnimail2 = new Animal();
            ICat2 = IAnimail2;//逆变
     */
    #endregion
}

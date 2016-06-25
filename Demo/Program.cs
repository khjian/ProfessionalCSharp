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
            int[] array = new[] {1, 2, 3, 4};
            var bag = Tuple.Create<int, double, string>(2009, 5.19, "str");
            Console.ReadLine();
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

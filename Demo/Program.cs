using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LINQ;

namespace Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var brazilRacers = from r in Formula1.GetChampion()
                where r.Country == "Brazil"
                orderby r.Wins
                select r;
            foreach (var racer in brazilRacers)
            {
                Console.WriteLine(racer);
            }
            Console.ReadKey();
        }

        #region int数组冒泡排序

        private static void sort(int[] sortArray)
        {
            var swapped = true;
            do
            {
                swapped = false;
                for (var i = 0; i < sortArray.Length - 1; i++)
                {
                    if (sortArray[i] > sortArray[i + 1])
                    {
                        var temp = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);

            //查看排序结果
            foreach (var item in sortArray)
            {
                Console.WriteLine(item);
            }
        }

        #endregion
    }

    #region Animal

    internal class Animal : IComparable<Animal>
    {
        public int CompareTo(Animal other)
        {
            return 1;
        }

        public virtual void Eat()
        {
            Console.WriteLine("Animail eat");
        }
    }

    #endregion

    #region Cat

    internal class Cat : Animal, IComparable<Cat>
    {
        public int CompareTo(Cat other)
        {
            return 1;
        }

        public override void Eat()
        {
            Console.WriteLine("Cat eat");
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

    public static class StringExtension
    {
        public static string FirstName(this string name)
        {
            var ix = name.LastIndexOf(' ');
            return name.Substring(0, ix);
        }

        public static string LastName(this string name)
        {
            var ix = name.LastIndexOf(' ');
            return name.Substring(ix + 1);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Demo.Delegates;

namespace Demo
{

    class Program
    {
        static void Main(string[] args)
        {
            var dealer = new CarDealer();

            var michael = new Consumer("Michael");
            dealer.NewCarInfo += michael.NewCarIsHere;

            dealer.NewCar("Ferrari");

            var sebastian = new Consumer("Sebastian");
            dealer.NewCarInfo += sebastian.NewCarIsHere;

            dealer.NewCar("Mercedes");

            dealer.NewCarInfo -= michael.NewCarIsHere;
            
            dealer.NewCar("Red Bull Racing");

            Console.ReadKey();
        }

        #region int数组冒泡排序
        static void sort(int[] sortArray)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Length - 1; i++)
                {
                    if (sortArray[i] > sortArray[i + 1])
                    {
                        int temp = sortArray[i];
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

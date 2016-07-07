using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Demo.Delegates;
using Demo.ListSamples;
using Demo.QueueSample;

namespace Demo
{

    class Program
    {
        static void Main(string[] args)
        {
            var dm = new DocumentManager();
            ProcessDocuments.Start(dm);

            for (int i = 0; i < 1000; i++)
            {
                var doc = new QueueSample.Document("Doc"+i.ToString(),"content");
                dm.AddDocument(doc);
                Console.WriteLine("Added document {0}",doc.Title);
                Thread.Sleep(new Random().Next(20));
            }

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


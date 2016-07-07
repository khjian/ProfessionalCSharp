using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Demo.Delegates;
using Demo.ListSamples;

namespace Demo
{

    class Program
    {
        static void Main(string[] args)
        {
            var graham = new Racer(7, "Graham", "Hill", "UK", 14);
            var emerson = new Racer(13, "Emerson", "Fittipaldi", "Brazil", 14);
            var mario = new Racer(16, "Mario", "Andretti", "USA", 12);
            
            //用集合初始化设定项添加
            var racers= new List<Racer>(20) {graham,emerson,mario};

            //显示调用Add()方法来添加
            racers.Add(new Racer(24,"Michale","Schumacher","Germany",91));
            racers.Add(new Racer(27,"Mika","Hakkinen","Finland",20));

            //使用List<T>类的AddRange()方法
            racers.AddRange(new Racer[]
            {
                new Racer(14,"Niki","Lauda","Austria",25),
                new Racer(21,"Alain","Prost","France",51),  
            });

            foreach (var racer in racers)
            {
                Console.WriteLine(racer.ToString());
            }

            //ForEach方法
            racers.ForEach(r=>Console.WriteLine($"{r:A}"));

            //使用Find方法查找单个元素
            racers.Add(new Racer(28,"Shujian","Song","China",90));
            Racer racer1 = racers.Find(r => r.Country == "China");
            Console.WriteLine($"{racer1:A}");

            //使用FindAll查询符合条件的集合
            List<Racer> bigWinners = racers.FindAll(r => r.Wins > 20);
            Console.WriteLine("BigWinners:");
            foreach (var bigWinner in bigWinners)
            {
                Console.WriteLine($"{bigWinner:A}");
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


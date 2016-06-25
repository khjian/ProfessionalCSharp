using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    /// <summary>
    /// 泛型类的例子
    /// </summary>
    public class SortHelper<T> where T:IComparable
    {
        /*
         测试代码：
         var sorter1 = new SortHelper<int>();
            int[] arr = {4, 2, 1, 3, 9, 8};
            sorter1.BubbleSort(arr);
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
             */
        public void BubbleSort(T[] arr)
        {
            int length = arr.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }


        /// <summary>
        /// 泛型方法，不依赖于泛型类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /*
        public void BubbleSort<T>(T[] arr) where T: IComparable
        {
            int length = arr.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        } */
    }

    /*  
     SortHelper<cat> sort = new SortHelper<cat>();
            var cat1 = new cat("猫1",1000);
            var cat2 = new cat("猫2", 1500);
            var cat3 = new cat("猫1", 400);
            cat[] catArray = {cat1, cat2, cat3};
            sort.BubbleSort(catArray);
            foreach (var cat in catArray)
            {
                Console.WriteLine("Name:"+cat.name+" Price:"+cat.price);
            }
         */
    /// <summary>
    /// 测试排序用的类
    /// </summary>
    public class cat : IComparable
    {
        public string name;
        public int price;

        public int CompareTo(object obj)
        {
            cat catT = (cat) obj;
            return price.CompareTo(catT.price);
        }

        public cat(string name, int price)
        {
            this.price = price;
            this.name = name;
        }
    }
}

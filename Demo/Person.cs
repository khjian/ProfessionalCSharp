using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    //此例讲解迭代器
    /*
      Person[] persons = new Person[3]
            {
                new Person("man1"),
                new Person("man2"),
                new Person("man3")  
            };
            People people =new People(persons);
            foreach (var item in people)
            {
                Console.WriteLine(item.Name);
            }
         */
    public class Person
    {
        public string Name;

        public Person(string name)
        {
            Name = name;
        }
    }

    //定义People类，People为Person的复数
    public class People : IEnumerable
    {
        private Person[] _persons;

        public People(Person[] pArrary)
        {
            _persons = new Person[pArrary.Length];
            for (int i = 0; i < pArrary.Length; i++)
            {
                _persons[i] = pArrary[i];
            }
        }

        ////IEnumerable和IEnumerator通过IEnumerable的GetEnumerator()方法建立了连接，
        ///可以通过IEnumerable的GetEnumerator()得到IEnumerator对象。
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_persons);
        }
    }

    public class PeopleEnum:IEnumerator
    {
        public Person[] Persons;

        public PeopleEnum(Person[] pArray)
        {
            Persons = pArray;
        }

        //游标
        private int _position = -1;

        //是否可以往下移
        public bool MoveNext()
        {
            _position++;
            return (_position<Persons.Length);
        }

        //集合的所有元素取完之后，重置position
        public void Reset()
        {
            _position = -1;
        }

        //实现 IEnumerator的 Current方法 返回当前所指的Person对象
        object IEnumerator.Current {
            get
            {
                return  Current;
            }
        }

        //Current是返回Person类实例的只读方法
        public Person Current
        {
            get
            {
                try
                {
                    return Persons[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}

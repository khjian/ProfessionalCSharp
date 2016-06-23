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
           var list1 = new LinkedList();
            list1.AddLast(2);
            list1.AddLast(4);
            list1.AddLast("6");
            foreach (var i in list1)
            {
                Console.WriteLine(i);
            }
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

        }
    }
    #endregion

    #region LinkedListNode
    public class LinkedListNode
    {
        public LinkedListNode(object value)
        {
            this.Value = value;
        }

        public object Value { get; private set; }

        public LinkedListNode Next { get; internal set; }
        public LinkedListNode Prev { get; internal set; }
    }
    #endregion

    #region LinkedList

    public class LinkedList : IEnumerable
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }

        public LinkedListNode AddLast(object node)
        {
            var newNode = new LinkedListNode(node);
            if (First == null)
            {
                First = newNode;
                Last = First;
            }
            else
            {
                LinkedListNode previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }

        public IEnumerator GetEnumerator()
        {
            LinkedListNode current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
    #endregion

}

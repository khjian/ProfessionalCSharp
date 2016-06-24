using System;
using System.Collections;

namespace Demo
{
    /*
    示例代码：
     BankCard bc = new BankCard(1,1,1);
            CreditCard cc = new CreditCard(1,1,1);
            var wallet = new Wallet<CreditCard> {cc};
            var wallet2 = new Wallet<int>();
            wallet2.Add(2);
            Console.WriteLine(wallet[0]);
        */
    #region 钱包物品基类

    public class WalletThingBase
    {
        protected readonly int MaxLength = 10;
        protected readonly int MaxThickness = 1;
        protected readonly int MaxWidth = 7;

        private int _length;
        private int _thickness;
        private int _width;

        public WalletThingBase(int length, int width, int thickness)
        {
            Length = length;
            Width = width;
            Thickness = thickness;
        }

        public int Length
        {
            get { return _length; }
            set
            {
                if (value <= 0 || value > MaxLength)
                {
                    throw new ArgumentException("Length is invalid");
                }
                _length = value;
            }
        }

        public int Width
        {
            get { return _width; }

            set
            {
                if (value <= 0 || value > MaxWidth)
                {
                    throw new ArgumentException("Width is invalid");
                }
                _width = value;
            }
        }

        public int Thickness
        {
            get { return _thickness; }

            set
            {
                if (value <= 0 || value > MaxThickness)
                {
                    throw new ArgumentException("Thinkness is invalid.");
                }
                _thickness = value;
            }
        }
    }

    #endregion


    public class BankCard : WalletThingBase
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public string Password { get; set; }

        public BankCard(int length, int width, int thickness) : base(length, width, thickness)
        {
        }
    }

    public class CreditCard : BankCard
    {
        public decimal Overdraft { get; set; }

        public CreditCard(int length, int width, int thickness) : base(length, width, thickness)
        {
        }
    }

    public class Wallet<T>:CollectionBase
    {
        public Wallet()
        {
            Type baseType = typeof(T).BaseType;
            while (baseType != null
                && baseType != typeof(Object)
               && baseType.BaseType != typeof(Object))
            {
                baseType = baseType.BaseType;
            }

            if (baseType != typeof(WalletThingBase))
            {
                throw new Exception(typeof(T) + "cannot be put into wallet");
            }
        }

        public T this[int index]
        {
            get { return (T) List[index]; }
            set { List[index] = value; }
        }

        public int Add(T item)
        {
            return List.Add(item);
        }

        public void Remove(T item)
        {
            List.Remove(item);
        }
    }
}
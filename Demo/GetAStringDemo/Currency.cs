using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.GetAStringDemo
{
    struct Currency
    {
        public uint Dollars;
        public ushort Cents;

        public Currency(uint dollars, ushort cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }

        public override string ToString()
        {
            return $"${Dollars}.{Cents,2:00}";
        }

        public static string GetCurrencyUnit()
        {
            return "Dollar";
        }

        public static implicit operator float(Currency value)
        {
            return value.Dollars + (value.Cents/100.0f);
        }

        public static implicit operator Currency(uint value)
        {
            return new Currency(value,0);
        }

        public static implicit operator uint(Currency value)
        {
            return value.Dollars;
        }
    }

}

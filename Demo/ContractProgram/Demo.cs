using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ContractProgram
{
    public class Demo
    {
        public int Deposit(int amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(Balance == Contract.OldValue(Balance) + amount);
            Balance += amount;
            return Balance;
        }

        public int Balance { get; set; }
    }
}

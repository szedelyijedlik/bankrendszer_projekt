using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankrendszer
{
    internal class Account
    {
        public string Name { get; private set; }
        public int Balance { get; private set; }

        public Account(string name, int startingBalance)
        {
            Name = name;
            Balance = startingBalance;
        }
    }
}

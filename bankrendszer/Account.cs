using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankrendszer
{
    internal class Account
    {
        public string Number { get; private set; }
        public string Name { get; private set; }
        public int Balance { get; private set; }

        public Account(string name, int startingBalance)
        {
            this.Number = Guid.NewGuid().ToString().Split("-")[0];
            Name = name;
            Balance = startingBalance;
        }

        public void AddMoney(int amount)
        {
            this.Balance += amount;
        }
        
        public bool Expense(int amount)
        {
            if (Balance < amount)
            {
                return false;
            }
            this.Balance -= amount;
            return true;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankrendszer
{
    internal class Client
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public List<Account> Accounts {  get; private set; } 
        public int Income { get; private set; }

        Random rand = new Random();
        public Client(string name, string email)
        {
            this.Name = name;
            this.Email = email;
            this.Accounts = new List<Account>();
            this.Income = rand.Next(190500, 1000000);
        }

        public void CreateAccount(string name, int startingBalance = 0)
        {
            if (name != "")
            {
                if (startingBalance >= 0)
                {
                    this.Accounts.Add(new Account(name, startingBalance));
                }
                else
                {
                    throw new Exception("A kezdőösszeg nem lehet kisebb 0 forintnál");
                }
            }
            else
            {
                throw new Exception("Hibás névmegadás");
            }
        }
    }
}

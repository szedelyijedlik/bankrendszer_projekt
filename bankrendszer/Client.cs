using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankrendszer
{
    internal class Client
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public string Email { get; private set; }
        public List<Account> Accounts {  get; private set; } 

        public Client(string name, DateTime dateOfBirth, string gender, string email)
        {
            this.Name = name;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.Accounts = new List<Account>();
        }
    }
}

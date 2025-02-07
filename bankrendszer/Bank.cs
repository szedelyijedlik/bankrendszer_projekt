using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankrendszer
{
    internal class Bank
    {
        public List<Client> Clients { get; set; }

        public Bank()
        {
            Clients = new List<Client>();
        }

        public Client SearchClient(string name)
        {

        }

        public List<Client> ListClients()
        {
            return Clients;
        }

        public void AddClient(string newClientName)
        {
        }
    }
}

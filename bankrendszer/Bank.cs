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

        public List<Client> ListClients()
        {
            return Clients;
        }

        public void AddClient(string newClientName, string newClientEmail)
        {
            if (newClientName != "" && newClientEmail != "")
            {
                this.Clients.Add(new Client(newClientName, newClientEmail));
            }
            else
            {
                throw new Exception("Hibás adatok");
            }
        }

        public Client SearchClient(string clientName)
        {
            if (clientName != "")
            {
                int i = 0;
                while (i < this.Clients.Count && this.Clients[i].Name.ToLower() != clientName.ToLower())
                {
                    i++;
                }

                if (i < this.Clients.Count)
                {
                    return Clients[i];
                }
                else
                {
                    throw new Exception("Ilyen névvel nem található ügyfél");
                }
            }
            else
            {
                throw new Exception("Hibás adatok");
            }
        }
    }
}

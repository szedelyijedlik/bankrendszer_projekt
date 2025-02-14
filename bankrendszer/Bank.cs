using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankrendszer
{
    internal class Bank
    {
        public List<Client> Clients { get; private set; }
        public List<Log> Logs { get; private set; }

        public Bank()
        {
            Clients = new List<Client>();
            Logs = new List<Log>();
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

        public void NextMonth(DateTime oldDate, DateTime newDate)
        {
            int diffOfDates = (newDate - oldDate).Days;
            Random rand = new Random();

            for (int i = 0; i < diffOfDates; i++)
            {
                foreach (var client in Clients)
                {
                    int amount = 0;
                    if (rand.Next(1, 7) > 5)
                    {
                        amount = rand.Next(2000, 5000);
                    }
                    else if (rand.Next(1, 15) > 13)
                    {
                        amount = rand.Next(20000, 50000);
                    }
                    if (client.Accounts.Count > 0 && amount > 0)
                    {
                        if (client.Accounts[0].Expense(amount))
                        {
                            Logs.Add(new Log(oldDate.AddDays(i), $"{client.Name} költött {amount.ToString("N0")} forintot."));
                        }
                        else
                        {
                            Logs.Add(new Log(oldDate.AddDays(i), $"{client.Name} megpróbált költeni {amount.ToString("N0")} forintot, de nem volt rá fedezete."));
                        }
                    }
                }
            }
            SalaryDay(newDate);
        }

        private void SalaryDay(DateTime date)
        {
            foreach (var client in Clients)
            {
                if (client.Accounts.Count > 0)
                {
                    client.Accounts[0].AddMoney(client.Income);
                    Logs.Add(new Log(date, $"{client.Name} megkapta a fizetését ({client.Income.ToString("N0")} Ft)."));
                }
            }
        }

        public void TransferMoney(Client client, string transferFrom, string transferTo)
        {
            if (transferFrom != "" && transferTo != "")
            {
                int i = 0;
                while (i < client.Accounts.Count && client.Accounts[i].Number != transferFrom)
                {
                    i++;
                }
                if (i! < client.Accounts.Count)
                {
                    throw new Exception("Jogosulatlan erre a műveletre vagy nem létező terhelendő számla");
                }

                int j = 0;
                for (int n = 0; n < Clients.Count; n++)
                {
                    j = 0;
                    while (j < Clients[n].Accounts.Count && Clients[n].Accounts[j].Number != transferTo)
                    {
                        j++;
                    }
                    if (j < Clients[n].Accounts.Count)
                    {
                        break;
                    }
                    j = 0;
                }
                if (j == 0)
                {
                    throw new Exception("Nem létező kedvezményezett számla");
                }

                
            }
            else
            {
                throw new Exception("Hibás adatmegadás");
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace bankrendszer
{
    internal class Program
    {
        static DateTime date = DateTime.Now.Date;
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            bank.AddClient("Lakatos Mihály", "lakatos.mihaly@gmail.com");
            bank.SearchClient("Lakatos Mihály").CreateAccount("Főszámla", 20000);
            bank.SearchClient("Lakatos Mihály").CreateAccount("Másik számla", 5000);
            bank.AddClient("Marok László", "marok.laszlo444@gmail.com");
            bank.SearchClient("Marok László").CreateAccount("Főszámla", 40000);
            bank.AddClient("Bokor Málna", "bokor.malna@gmail.com");

            int choice = -1;
            while (choice != 0)
            {
                Console.CursorVisible = false;
                Console.Clear();
                choice = Menu();
                Console.CursorVisible = true;
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\t\tÚj ügyfél rögzítése\t\t");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("----------------------------------------------");
                        Console.Write("Új ügyfél neve: ");
                        string newClientName = Console.ReadLine()!;
                        Console.Write("Új ügyfél email címe: ");
                        string newClientEmail = Console.ReadLine()!;
                        try
                        {
                            bank.AddClient(newClientName, newClientEmail);
                            Console.WriteLine("Sikeres ügyfélfelvétel.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"HIBA: {ex.Message}.");
                        }
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.Write("Adja meg a keresendő ügyfél nevét: ");
                        string clientToSearch = Console.ReadLine()!;
                        try
                        {
                            Client client = bank.SearchClient(clientToSearch);
                            int cChoice = -1;
                            while (cChoice != 0)
                            {
                                PrintClientDetails(client);
                                cChoice = cMenu();
                                switch(cChoice)
                                {
                                    case 1:
                                        PrintClientDetails(client);
                                        if (client.Accounts.Count > 0)
                                        {
                                            Console.Write("Új számla megnevezése: ");
                                            string newAccountName = Console.ReadLine()!;
                                            client.CreateAccount(newAccountName);
                                        }
                                        else
                                        {
                                            client.CreateAccount("Főszámla", 10000);
                                        }
                                        break;
                                    case 2:
                                        PrintClientDetails(client);
                                        Console.Write("Terhelendő számla száma: ");
                                        string transferFrom = Console.ReadLine()!;
                                        Console.Write("Kedvezményezett számla száma: ");
                                        string transferTo = Console.ReadLine()!;
                                        Console.Write("Utalandó összeg: ");
                                        int amount = int.Parse(Console.ReadLine()!);

                                        Random rand = new Random();
                                        bank.TransferMoney(client, date.AddDays(rand.Next(1, 20)), transferFrom, transferTo, amount);
                                        break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"HIBA: {ex.Message}.");
                        }
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("\t\tÜgyfelek listája\t\t");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("----------------------------------------------");

                        foreach (var client in bank.ListClients())
                        {
                            Console.WriteLine($"{client.Name} ({client.Email}) - Számlák: {client.Accounts.Count} db");
                        }
                        Console.ReadKey(true);
                        break;
                    case 4:
                        bank.NextMonth(date, date.AddMonths(1));
                        Console.WriteLine($"\t{date.ToString("yyyy-MM-dd")} - {date.AddMonths(1).ToString("yyyy-MM-dd")}");
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine();
                        foreach (var log in bank.Logs)
                        {
                            if (log.Date > date)
                            {
                                Console.WriteLine($"{log.Date.ToString("yyyy-MM-dd")} - {log.LogMessage}");
                            }
                        }
                        date = date.AddMonths(1);
                        Console.ReadKey();
                        break;
                }
            }
        }
        static public int Menu()
        {
            Console.WriteLine($"\t{date.ToString("yyyy-MM-dd")}\n");
            Console.WriteLine("1 - Ügyfél létrehozása");
            Console.WriteLine("2 - Ügyfél kezelés");
            Console.WriteLine("3 - Ügyfelek listája");
            Console.WriteLine("\n4 - Következő hónap");
            Console.WriteLine("\n0 - Kilépés");

            char input;
            do
            {
                input = Console.ReadKey(true).KeyChar;
            }
            while (input < '0' || input > '4') ;
            return input - '0';
        }

        static public int cMenu()
        {
            Console.WriteLine("0 - Mégse");
            Console.WriteLine("1 - Számla nyitása");
            Console.WriteLine("2 - Utalás/Számlák közötti átvezetés");

            char input;
            do
            {
                input = Console.ReadKey(true).KeyChar;
            }
            while (input < '0' || input > '3');
            return input - '0';
        }

        static public void PrintClientDetails(Client client)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\t\tÜgyfél kezelése\t\t");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"{client.Name} ({client.Email})");
            Console.WriteLine("\nSzámla:");
            foreach (var account in client.Accounts)
            {
                Console.WriteLine($"\tSzámlaszám: {account.Number} | Számla név: {account.Name} | Egyenleg: {account.Balance.ToString("N0")} Ft");

            }
            Console.WriteLine("----------------------------------------------");
        }
    }
}

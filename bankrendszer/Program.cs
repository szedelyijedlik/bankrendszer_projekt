using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace bankrendszer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            bank.AddClient("Lakatos Mihály", "lakatos.mihaly@gmail.com");
            bank.AddClient("Marok László", "marok.laszlo444@gmail.com");
            bank.SearchClient("Marok László").CreateAccount("Folyószámla", 40000);

            int choice = -1;
            while (choice != 0)
            {
                Console.Clear();
                choice = Menu();
                Console.Clear();
                switch (choice)
                {
                    case 1:
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
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\t\tÜgyfél kezelése\t\t");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("----------------------------------------------");
                            Client client = bank.SearchClient(clientToSearch);
                            Console.WriteLine($"{client.Name} ({client.Email})");
                            Console.WriteLine("\nSzámlái:");
                            for (int i = 0; i < client.Accounts.Count; i++)
                            {
                                Console.WriteLine($"\tID: {i} | Számla név: {client.Accounts[i].Name} | Számla egyenleg: {client.Accounts[i].Balance} Ft");
                            }

                            Console.WriteLine("----------------------------------------------");
                            int cChoice = -1;
                            while (cChoice != 0)
                            {
                                cChoice = clientMenu();
                                switch(cChoice)
                                {
                                    case 1:
                                        break;
                                }
                            }
                            Console.ReadKey(true);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"HIBA: {ex.Message}.");
                        }
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.WriteLine("Ügyfelek listája:");

                        foreach(var client in bank.ListClients())
                        {
                            Console.WriteLine($"\t{client.Name} - {client.Email}");
                        }
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        static public int Menu()
        {
            Console.WriteLine("1 - Ügyfél létrehozása");
            Console.WriteLine("2 - Ügyfél kezelés");
            Console.WriteLine("3 - Ügyfelek listája");
            Console.WriteLine("\n0 - Kilépés");

            char input;
            do
            {
                input = Console.ReadKey(true).KeyChar;
            }
            while (input < '0' || input > '3') ;
            return input - '0';
        }

        static public int clientMenu()
        {
            Console.WriteLine("1 - Ügyfél számláinak kezelése");
            Console.WriteLine("2 - Ügyfél email módosítás");
            Console.WriteLine("\n0 - Kilépés");

            char input;
            do
            {
                input = Console.ReadKey(true).KeyChar;
            }
            while (input < '0' || input > '3');
            return input - '0';
        }
    }
}

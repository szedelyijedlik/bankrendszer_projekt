using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace bankrendszer
{
    internal class Program
    {
        static DateTime day = DateTime.Now.Date;
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            bank.AddClient("Lakatos Mihály", "lakatos.mihaly@gmail.com");
            bank.AddClient("Marok László", "marok.laszlo444@gmail.com");
            bank.SearchClient("Marok László").CreateAccount("Folyószámla", 40000);

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
                            foreach (var account in client.Accounts)
                            {
                                Console.WriteLine($"\tSzámlaszám: {account.Number} | Számla név: {account.Name} | Egyenleg: {account.Balance} Ft");
                                
                            }
                            Console.WriteLine("----------------------------------------------");
                            
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
                            Console.WriteLine($"{client.Name} ({client.Email}) - Számlák száma: {client.Accounts.Count}");
                        }
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        static public int Menu()
        {
            Console.WriteLine($"\t{day.ToString("yyyy-MM-dd")}\n");
            Console.WriteLine("1 - Ügyfél létrehozása");
            Console.WriteLine("2 - Ügyfél kezelés");
            Console.WriteLine("3 - Ügyfelek listája");
            Console.WriteLine("\n4 - Következő nap");
            Console.WriteLine("5 - Log megtekintése");
            Console.WriteLine("\n0 - Kilépés");

            char input;
            do
            {
                input = Console.ReadKey(true).KeyChar;
            }
            while (input < '0' || input > '3') ;
            return input - '0';
        }
    }
}

using System.Security.Cryptography.X509Certificates;

namespace bankrendszer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            int choice = Menu();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        string newClientName = Console.ReadLine()!;
                        bank.AddClient(newClientName);
                        break;

                    case 2:
                        break;
                }
            }
        }
        static public int Menu()
        {
            Console.WriteLine("1 - Ügyfél létrehozása");
            Console.WriteLine("2 - Ügyfél keresés");
            Console.WriteLine("3 - Ügyfél listázás");
            Console.WriteLine("\n0 - Kilépés");

            char input;
            do
            {
                input = Console.ReadKey().KeyChar;
            }
            while (input < '0' || input > '3') ;
            return input - '0';
        }
    }
}

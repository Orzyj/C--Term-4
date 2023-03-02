using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Wprowadź liczbe: ");
                int number;

                try
                {
                    number = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    number = -1;
                    Console.WriteLine(e.Message);
                    return;
                }
                Console.WriteLine("Podana liczba {0} liczbą pierwsza", (check(number) ? "jest" : "nie jest"));
                Console.ReadLine();
            }
        }

        private static bool check(int n)
        {
            if (n < 2) return false;
            for(int i = 2; i*i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}

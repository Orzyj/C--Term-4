using System;

namespace ConsoleApp1
{
    class Program
    {
        private static void Main(string[] args)
        {
            int n, k;

            try
            {
                Console.WriteLine("Wprowadź liczbe K: ");
                k = int.Parse(Console.ReadLine());

                Console.WriteLine("Wprowadź stopień pierwiastka n: ");
                n = int.Parse(Console.ReadLine());

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Pierwiastek {0}-tego stopnia z {1}, wynosi: {2}", n, k, fun(n, k));
        }
        private static double fun(int n, int k)
        {
            return Math.Pow(k, 1.0 / n);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true){
                Console.WriteLine("liczba {0} trojkatna", (Math.Sqrt(8 * int.Parse(Console.ReadLine()) + 1) % 1 == 0 ? "jest" : "nie jest"));
            }
        }
    }
}

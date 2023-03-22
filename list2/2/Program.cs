using System;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            Convert x = new Convert();
            while (true)
            {
                Console.WriteLine("Podaj liczbe binarną: ");
                x.binaryValue = Console.ReadLine();
                Console.WriteLine($"Liczba binarna: {x.binaryValue}\nSystem dziesiętny {x.convertDecimal()}\nSystem oktalny: {x.convertOctagonal()}\nSystem heksadecymalny: {x.convertHex()}\nSystem piątkowy: {x.convertFive()}\n");
            }
        }
    }
}
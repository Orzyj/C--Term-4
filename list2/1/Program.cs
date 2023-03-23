using System;
using System.Collections.Generic;

namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Liczby> collection = new List<Liczby>();
            uint n;

            Console.WriteLine("Podaj wartość n: ");
            n = uint.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Liczby x = new Liczby();
                
                int number = random.Next(-100, 101);
                bool w = false;
                for (int j = 0; j < collection.Count; j++)
                    if (collection[j].value == number)
                        w = true;
                if (w == false)
                    x.value = number;
                x.generateValues();
                collection.Add(x);
            }

            foreach (var element in collection)
                Console.WriteLine(element.showValues());
        }
    }
}

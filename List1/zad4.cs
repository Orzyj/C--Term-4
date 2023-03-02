using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                float a, b, c, d;
                try
                {
                    Console.WriteLine("Wprowadź liczbe a: ");
                    a = float.Parse(Console.ReadLine());

                    Console.WriteLine("Wprowadź liczbe b: ");
                    b = float.Parse(Console.ReadLine());

                    Console.WriteLine("Wprowadź liczbe c: ");
                    c = float.Parse(Console.ReadLine());

                    d = (float)Math.Pow(b, 2) - (4 * a * c);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    return;
                }

                if (d > 0)
                {
                    Console.WriteLine("Występują dwa miejsca zerowe: [1]: {0} oraz [2]: {1}", ((-1 * b - Math.Sqrt(d)) / (2 * a)), ((-1 * b + Math.Sqrt(d)) / (2 * a)));
                }
                else if (d == 0)
                {
                    Console.WriteLine("Występuje jedno miejsce zerowe [1]: {0}", (-1 * b) / 2 * a);
                }
                else
                {
                    Console.WriteLine("Parabola {0} osią, brak miejsc zerowych", (a > 0) ? "nad" : "pod");
                }
            }
            
        }
    }
}

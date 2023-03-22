using System;

namespace zad1
{
    class Liczby
    {
        public int value { get; set; }
        public int absValue { get; set; }
        public bool parity { get; set; }

        public void generateValues()
        { 
            absValue = Math.Abs(value);
            parity = value % 2 == 0 ? true : false;
        }

        public string showValues()
        {
            return $"Wartość: \t{value}\tWartość bezwzględna:\t{absValue}\tParzystość:\t"+(parity ? "tak" : "nie");
        }
    }
}

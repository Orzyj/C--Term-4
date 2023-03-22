using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Klient
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public int pin { get; set; }
        public int kodBezpieczenstwa { get; set; }
        public int stanKonta { get; set; }


        public Klient(string Imie, string Nazwisko, int pin, int kodBezpieczenstwa, int stanKonta, string Login)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.pin = pin;
            this.kodBezpieczenstwa = kodBezpieczenstwa;
            this.stanKonta = stanKonta;
            this.Login = Login;
        }
        public void pokazInformacjeKonto()
        {
            Console.WriteLine($"------------\nKonto:\nImie: {this.Imie}\nNazwisko: {this.Nazwisko}\nSaldo: {this.stanKonta}\n-------------------");
        }
        public bool logowanie(string login, int pin)
        {
            return this.pin == pin && this.Login.Equals(login) ? true : false;
        }
        public void zmienPin(int kodBezpieczenstwa)
        {
            if(this.kodBezpieczenstwa == kodBezpieczenstwa)
            {
                int pin1, pin2;
                Console.WriteLine("Podaj nowy pin: ");
                pin1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Potwiedź pin: ");
                pin2 = int.Parse(Console.ReadLine());

                if (pin1 == pin2)
                {
                    this.pin = pin1;
                    Console.WriteLine("Zmieniono pin!");
                } else
                {
                    Console.WriteLine("Nie zmieniono pinu!");
                }
            }
        }
        public int pokazStanKonta()
        {
            return this.stanKonta;
        }
        public void dodajSaldo(int kwota)
        {
            this.stanKonta += kwota;
        }
        public void odejmijSaldo(int kwota)
        {
            this.stanKonta -= kwota;
        }
    }
}

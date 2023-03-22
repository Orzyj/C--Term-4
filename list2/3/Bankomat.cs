using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Bankomat
    {
        public Dictionary<string, int> listaBanknotow;
        public List<Klient> klienci;
        public int IDKlienta;
        public bool zalogowany = false;
        
        public Bankomat()
        {
            this.listaBanknotow = new Dictionary<string, int>();
            this.klienci = new List<Klient>();
            this.losowanieNominalow();

            Klient k1 = new Klient("Adam", "Małysz", 2222, 345, 2000, "Adam123");
            Klient k2 = new Klient("Bartosz", "Młody", 3333, 555, 4000, "Bartek@");
            Klient k3 = new Klient("Ewa", "Starsza", 4444, 333, 500000, "Ewa96");
            this.klienci.Add(k1);
            this.klienci.Add(k2);
            this.klienci.Add(k3);
        }
        public void losowanieNominalow()
        {
            Random random = new Random();
            string[] nominaly = {"10", "20","50","100","200","500" };
            Console.WriteLine("W bankomacie znajduje się: ");
            for (int i = 0; i < nominaly.Length; i++)
            {
                int liczbaBanknotow = random.Next(5, 10);
                this.listaBanknotow.Add(nominaly[i], liczbaBanknotow);
            }
        }
        public void sprawdzanieZalogowanegoKlienta(string login, int pin)
        {
            for (int i = 0; i < klienci.Count; i++)
                if (klienci[i].logowanie(login, pin))
                {
                    this.IDKlienta = i;
                    this.zalogowany = true;
                    return;
                }
        }
        public void start()
        {
            string login;
            int pin;
            while (true)
            {
                this.pokazBanknoty();
                Console.WriteLine("---------\nWitaj, zaloguj sie do swojego konta!\nPodaj login:");
                login = Console.ReadLine();
                Console.WriteLine("Podaj pin: ");
                pin = int.Parse(Console.ReadLine());

                for (int i = 0; i < klienci.Count; i++)
                {
                    sprawdzanieZalogowanegoKlienta(login, pin);
                }
                if (zalogowany) this.menu();
                else Console.WriteLine("Nie zalogowano");
            }
        }
        public void pokazBanknoty()
        {
            Console.WriteLine("------------------");
            foreach (KeyValuePair<string, int> banknot in this.listaBanknotow)
                Console.WriteLine($"Nominał: {banknot.Key} liczba sztuk: {banknot.Value}");
        }
        public void wyloguj()
        {
            this.zalogowany = false;
            this.IDKlienta = 1000;
        }
        public void wplataNaKonto()
        {
            int kwota;
            bool warunek = true;
            do
            {
                Console.WriteLine("Podaj kwota która chcesz wpłacić: ");
                kwota = int.Parse(Console.ReadLine());
                if (kwota % 10 != 0) Console.WriteLine("Podana kwota nie może zawierać monet, wyłacznie banknoty!");
                else warunek = false;
            } while (warunek);

            Dictionary<string, int> banknoty = new Dictionary<string, int>();
            string[] nominaly = { "10", "20", "50", "100", "200", "500" };
            int sprawdzenieKwoty = 0;

            Console.WriteLine("Wprowadź ilość banknotów które posiadasz: ");
            for(int i = 0; i < nominaly.Length; i++)
            {
                int liczbaBanknotowODanymNominale;
                Console.Write($"{nominaly[i]}zł: ");
                liczbaBanknotowODanymNominale = int.Parse(Console.ReadLine());
                sprawdzenieKwoty += int.Parse(nominaly[i]) * liczbaBanknotowODanymNominale;
                banknoty.Add(nominaly[i], liczbaBanknotowODanymNominale);
            }

            if(kwota == sprawdzenieKwoty)
            {
                Console.WriteLine("Podane kwoty sie zgadzają");
                
                //aktualizacja stanu banknotów w bankomacie
                for(int i = 0; i < nominaly.Length; i++)
                   this.listaBanknotow[nominaly[i]] += banknoty[nominaly[i]];

                //aktualizacja konta użytkownika
                this.klienci[this.IDKlienta].dodajSaldo(kwota);
            } else
            {
                Console.WriteLine("Podane kwoty sie nie zgadzają, zakończenie operacji nie powodzeniem");
            }
        }
        public void wyplataZKonta()
        {
            int kwota, kwota_p;
            bool warunek = true;
            do
            {
                Console.WriteLine("Podaj kwota która chcesz wybrać z bankomatu: ");
                kwota = int.Parse(Console.ReadLine());
                if (kwota % 10 != 0) Console.WriteLine("Podana kwota nie może zawierać monet, wyłacznie banknoty!");
                else if(this.klienci[this.IDKlienta].pokazStanKonta() < kwota)
                {
                    Console.WriteLine("Nie masz wystarczajacych środków na koncie!");
                    return;
                }
                else warunek = false;
            } while (warunek);

            //stworzenie kwoty pomocniczej
            kwota_p = kwota;

            string[] nominaly = { "10", "20", "50", "100", "200", "500" };
            Dictionary<string, int> nominalydoOdjecia = new Dictionary<string, int>();

            for (int i = nominaly.Length - 1; i >= 0; i--)
            {
                int nominal = int.Parse(nominaly[i]);
                int liczbaNominalowWbankomacie = this.listaBanknotow[nominaly[i]];
                int liczbaNominalowDoOdjecia = 0;
                while (liczbaNominalowWbankomacie > 0 && kwota >= nominal)
                {
                    kwota -= nominal;
                    liczbaNominalowWbankomacie--;
                    liczbaNominalowDoOdjecia++;
                }
                nominalydoOdjecia.Add(nominaly[i], liczbaNominalowDoOdjecia);
            }

            if(kwota == 0)
            {
                //aktualizacja banknotów w bankomacie
                for(int i = 0; i < nominaly.Length; i++)
                    this.listaBanknotow[nominaly[i]] -= nominalydoOdjecia[nominaly[i]];

                //ściągniecie z konta odpowiedniej kwoty
                this.klienci[this.IDKlienta].odejmijSaldo(kwota_p);

                Console.WriteLine($"Wypłacono {kwota_p}");
            } else
            {
                Console.WriteLine("Brak odpowiedniej ilości banknotów!");
            }
        }
        public void menu()
        {
            int wybor;
            this.klienci[this.IDKlienta].pokazInformacjeKonto();
            while (true)
            {
                Console.WriteLine($"------------------\nMenu\n1. Sprawdź stan konta\n2.Zmień pin\n3.Wpłata gotówki\n4.Wypłata gotówki\n5.Wyloguj\nPodaj opcje: ");
                wybor = int.Parse(Console.ReadLine());

                switch (wybor)
                {
                    case 1: Console.WriteLine($"Na twoim koncie znajduje sie: {this.klienci[this.IDKlienta].pokazStanKonta()}"); break;
                    case 2:
                        {
                            int kodBezpieczenstwa;
                            Console.WriteLine("Podaj swój kod bezpieczeństwa do zmiany pinu: ");
                            kodBezpieczenstwa = int.Parse(Console.ReadLine());
                            this.klienci[this.IDKlienta].zmienPin(kodBezpieczenstwa);
                        }
                        break;
                    case 3: this.wplataNaKonto(); break;
                    case 4: this.wyplataZKonta(); break;
                    case 5:
                        {
                            this.wyloguj();
                            Console.WriteLine("Wylogowano");
                            return;
                        }
                        break;
                }
                Console.WriteLine("------------------------\n");
            }
        }
    }
}

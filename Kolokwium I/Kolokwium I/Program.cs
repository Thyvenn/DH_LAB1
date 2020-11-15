using System;

namespace KolokwiumI
{
    class Program
    {
        static decimal CelsjuszaNaFarenheita(decimal celsjusza)
        {
            decimal farenheita = celsjusza * (5.0m / 9.0m) + 32;
            return farenheita;
        }


        static decimal FarenheitaNaCelsjusza(decimal farenheita)
        {
            decimal celsjusza = (farenheita - 32) / (5.0m / 9.0m);
            return celsjusza;
        }



        static decimal WynikTestu(int[] klucz, int[] odpowiedzi)
        {
            int poprawne = 0;
            for (int i = 0; i < klucz.Length; i++)
            {
                if (klucz[i] == odpowiedzi[i]) poprawne++;
            }
            return (decimal)poprawne / (decimal)klucz.Length * 100.0m;
        }
        // klasa do zadania 3
        class Samochod
        {
            public decimal Spalanie { get; private set; }
            decimal Paliwo
            {
                get
                {
                    return Paliwo;
                }
                set
                {
                    if (value >= 0 || value <= 50) Paliwo = value;
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            int Przebieg
            {
                get
                {
                    return Przebieg;
                }
                set
                {
                    if (value >= Przebieg) Przebieg = value;
                }
            }

            void Tankuj()
            {
                decimal cena = ((50 - Paliwo) * 4.5m);
                Console.WriteLine($"Cena tankowania: {cena}");
                Paliwo = 50;
            }

            void Jedz(int km)
            {
                if (km * Spalanie / 100.0m > Paliwo)
                {
                    Console.WriteLine("Nie starczy paliwa!");
                }
                else
                {
                    Przebieg += km;
                    Paliwo -= km * Spalanie / 100.0m;
                }
            }

        }
        static void Main(string[] args)
        {
            //zadanie 1
            {
                Console.Write("Wprowadź liczbe: ");
                string wejscie = Console.ReadLine();
                decimal liczba = decimal.Parse(wejscie);

                decimal f = CelsjuszaNaFarenheita(liczba);
                decimal c = FarenheitaNaCelsjusza(f);
                Console.WriteLine($"Celsjusza na farenheita: {f}");
                Console.WriteLine($"Farenheita na celsjusza: {c}");
            }

            //zadanie 2
            {

                Console.Write("Wprowadz ilosc pytan: ");
                string wejscie = Console.ReadLine();
                int iloscPytan = int.Parse(wejscie);

                var Klucze = new int[iloscPytan];
                for (int i = 0; i < iloscPytan; i++)
                {
                    Console.Write($"Wprowadz odpowiedz do pytania {i}: ");
                    string odpowiedz = Console.ReadLine();
                    int liczbaOdpowiedz = int.Parse(odpowiedz);
                    Klucze[i] = liczbaOdpowiedz;
                }

                var rand = new Random();

                var Odpowiedzi1 = new int[iloscPytan];
                var Odpowiedzi2 = new int[iloscPytan];

                for (int i = 0; i < iloscPytan; i++)
                {
                    Odpowiedzi1[i] = rand.Next(1, 4);
                    Odpowiedzi2[i] = rand.Next(1, 4);
                }


                decimal wynikTestu1 = WynikTestu(Klucze, Odpowiedzi1);
                decimal wynikTestu2 = WynikTestu(Klucze, Odpowiedzi2);

                Console.WriteLine($"Wynik testu 1 to {wynikTestu1}%");
                Console.WriteLine($"Wynik testu 2 to {wynikTestu2}%");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

/*
Stwórz dowolną klasę.Dodaj do niej publiczne pola lub właściwości do 
przechowania Id i dowolnej wartości tekstowej.Dodaj do klasy tablicę 
10 liczb całkowitych. Zaimplementuj w klasie interfejs ICloneable
[https://docs.microsoft.com/en-us/dotnet/api/system.icloneable?view=net-5.0#remarks].
Metoda Clone powinna tworzyć głęboką kopię obiektu - przepisywać wartości proste i przepisywać 
wartości do nowej tablicy. Zaimplementuj w klasie interfejs IComparable<T>(gdzie T to nazwa tej samej klasy)
[https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-5.0#examples]. 
Metoda CompareTo powinna sprawić, że elementy ułożą się alfabetycznie względem pola tekstowego.
Stwórz interfejs IPrintable i dodaj do niego metodę void Print().Zaimplementuj w klasie interfejs 
IPrintable.Metoda powinna wypisywać w przyjazny sposób wszystkie dane zapisane w klasie.
*/

namespace Zadanie
{
    interface IPrintable
    {
        void Print();
    }

    class Dowolna : ICloneable, IComparable<Dowolna>, IPrintable
    {
        public int Id;
        public string WartoscTekstowa;
        public int[] liczby = new int[10];

        public object Clone()
        {
            Dowolna d = new Dowolna();
            d.Id = Id;
            d.WartoscTekstowa = WartoscTekstowa;

            // głębokie kopiowanie
            for (int i = 0; i < liczby.Length; i++)
            {
                d.liczby[i] = liczby[i];
            }

            return d;
        }

        public int CompareTo(Dowolna d)
        {
            return WartoscTekstowa.CompareTo(d.WartoscTekstowa);
        }

        public void Print()
        {
            Console.Write($"ID={Id},WartoscTekstowa={WartoscTekstowa},liczba=[");
            for (int i = 0; i < liczby.Length; i++)
            {
                Console.Write($"{liczby[i]} ");
            }
            Console.Write($"]\n");
        }
    }

    class Program
    {
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "AĄBCĆDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static void Main()
        {
            // Stwórz tablicę 100 losowych elementów tej klasy
            Dowolna[] tablica = new Dowolna[100];

            for (int i = 0; i < tablica.Length; i++)
            {
                Dowolna d = new Dowolna();

                // id powinny być w kolejności 1, 2, 3...
                d.Id = i + 1;
                // tekst może być dowolny / losowy

                d.WartoscTekstowa = RandomString(10);
                // tablicę wypełnij losowymi liczbami
                Random rand = new Random();
                for (int j = 0; j < d.liczby.Length; j++)
                {
                    d.liczby[j] = rand.Next(10);
                }

                tablica[i] = d;
            }

            // Stwórz listę, do której dodasz klony elementów tablicy
            List<Dowolna> klony = new List<Dowolna>();

            for (int i = 0; i < tablica.Length; i++)
            {
                klony.Add((Dowolna)tablica[i].Clone());
            }

            // Wyzeruj tablice w oryginalnych obiektach ( tablice klonów powinny pozostać nienaruszone )
            for (int i = 0; i < tablica.Length; i++)
            {
                for (int j = 0; j < tablica[i].liczby.Length; j++)
                {
                    tablica[i].liczby[j] = 0;
                }
            }

            // Wywołaj na kolekcji metodę Sort.
            klony.Sort();

            // Wywołaj metodę Print z każdego elementu posortowanej kolekcji.
            foreach (Dowolna d in klony)
            {
                d.Print();
            }
        }
    }
}
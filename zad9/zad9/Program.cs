using System;
using System.Collections.Generic;

// Stwórz aplikację inspirowaną działaniem YouTube. 

namespace JUTUBE
{

    /*
        
        Dodaj także ExtensionMethod dla typu Kanał, która wypisze na konsolę nazwę 
        kanału, jego ilość subskrypcji i wyświetleń. Wywołaj Extension Method.
        Możesz dowolnie dostosować parametry metod, które nie zostały sprecyzowane,
        a także dowolnie zaimplementować klasę EventArgs eventu OpublikowanoFilm 
        w taki sposób, aby uzyskać opisany efekt.
    */
    static class KanalExtension
    {
        public static void Wypisz(this Kanal k)
        {
            Console.WriteLine($"{k.Nazwa}, ID:{k.Id}, suby: {k.LiczbaSubow}, wyswietlenia:{k.LicznikWyswietlen}");

        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //Stwórz kolekcję użytkowników i 1 Kanał. 
            List<Uzytkownik> uzytkownicy = new List<Uzytkownik>();
            Kanal kanal = new Kanal();
            kanal.Nazwa = "Skajfan";
            kanal.Id = 1; 

            Console.WriteLine("Pierwszy film");
            kanal.OpublikujFilm(); // 1szy invoke

            uzytkownicy.Add(new Uzytkownik("HikaruGM"));
            uzytkownicy.Add(new Uzytkownik("Klejnot Nilu"));
            uzytkownicy.Add(new Uzytkownik("Ragnarok"));
            uzytkownicy.Add(new Uzytkownik("Ulu mulu"));

            // Niech wszyscy użytkownicy subskrybują ten kanał. 
            foreach (Uzytkownik x in uzytkownicy)
            {
                x.SubskrybujKanał(ref kanal);
            }

            Console.WriteLine("Drugi film");
            kanal.OpublikujFilm(); //2gi invoke

            uzytkownicy.Add(new Uzytkownik("Sanjaya_z_Lechi"));
            uzytkownicy.Add(new Uzytkownik("Korwinedes z Mycken"));

            foreach (Uzytkownik x in uzytkownicy)
            {
                x.SubskrybujKanał(ref kanal);
            }

            Console.WriteLine("Trzeci film");
            //3ci invoke
            kanal.OpublikujFilm(); 

            kanal.Wypisz();
        }
    }
}
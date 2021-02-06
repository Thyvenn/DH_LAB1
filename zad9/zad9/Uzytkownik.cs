using System;
using System.Collections.Generic;
using System.Text;

namespace JUTUBE
{
    // Stwórz klasy Użytkownik i Kanał.
    // Do obu klas dodaj pola Nazwa i Id. 
    class Uzytkownik
    {
        public string Nazwa;
        public int Id;
        List<Kanal> subskrybowaneKanaly;

        public Uzytkownik(string n)
        {
            Nazwa = n;
            subskrybowaneKanaly = new List<Kanal>();
        }

        // Do klasy Użytkownik dodaj metodę SubskrybujKanał, 
        // która jako parametr przyjmie obiekt typu Kanał.
        public void SubskrybujKanał(ref Kanal k)
        {
            if (!subskrybowaneKanaly.Contains(k))
            {
                subskrybowaneKanaly.Add(k);
                k.LiczbaSubow++;
                //Metoda da powinna podpiąć Event Handler Użytkownika pod Event Kanału.
                k.OpublikowanoFilm += GdyFilmPublikowanyJest;
            }


        }

        void GdyFilmPublikowanyJest(object o, EventArgs e)
        {
            // W event handlerze wypisz krótkie potwierdzenie, 
            // np. "użytkownik X otrzymał powiadomienie o nowym filmie".
            Kanal k = (Kanal)o;
            Console.WriteLine($"użytkownik {Nazwa} otrzymał powiadomienie o nowym filmie od kanału {k.Nazwa}");
        }
    }
}

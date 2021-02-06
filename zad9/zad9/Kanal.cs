using System;
using System.Collections.Generic;
using System.Text;

namespace JUTUBE
{
    class Kanal
    {
        public string Nazwa;
        public int Id;

        // Do klasy Kanał dodaj pole LicznikWyswietlen,
        public int LicznikWyswietlen;
        public int LiczbaSubow;

        // i event OpublikowanoFilm.
        public EventHandler OpublikowanoFilm;

        //Metoda WyświetlFilm powinna zwiększać ilość wyświetleń o 1.
        public void WyswietlFilm(int id)
        {
            LicznikWyswietlen++;
        }

        // Metoda OpublikujFilm powinna publikować event. 
        public void OpublikujFilm()
        {
            OpublikowanoFilm?.Invoke(this, EventArgs.Empty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace Kolokwium_II
{



        //zad2
        abstract class Produkt
        {
            public decimal Cena;
        }

        class Mleko: Produkt
        {

        }

        class Promocja<T> where T : Produkt
        {
            public int wartosc;
            public T Produkt;
           


           public  decimal NowaCena()
            {
                return Produkt.Cena * ((100 - wartosc) / 100.0m);
            }
        }


    //zad3

    class System
    {
        public string login;
        public string haslo;

        public EventHandler Zalogowano;

        public void Zaloguj(string vlogin, string vhaslo)
        {
            if (vlogin == login && vhaslo == haslo)
            {
                Zalogowano?.Invoke(this, EventArgs.Empty);
            }
        }


    }

    class Logger
    {
        public List<string> logi = new List<string>();

        public void GdyZalogowano(object invoker, EventArgs argumenty)
        {
            System system = (System)invoker;
            string log = $"{DateTime.Now.ToString()} - zalogowal sie user {system.login}";
            logi.Add(log);
        }
        

    }

    class Aktywni
    {
        public int ilosc;
        public void GdyZalogowano(object invoker, EventArgs argumenty)
        {
            ilosc++;
        }

    }


    class Program
    {




        static void Main(string[] args)
        {



            //zad1
            Dictionary<int, string> slownikLiczb = new Dictionary<int, string>();

            string[] liczbySlowa = { "zero", "jeden", "dwa", "trzy", "cztery", "piec", "szesc", "siedem", "osiem", "dziewiedz" };

            for (int i = 0; i <=9; i++)
            {
                slownikLiczb[i] = liczbySlowa[i];
            }

            Console.Write("Wpisz nr telefonu: ");

            string numer = Console.ReadLine();

            for (int i = 0; i < numer.Length; i++)
            {
                int cyfra = Convert.ToInt32(numer[i].ToString());
                string cyfraSlownie = slownikLiczb[cyfra];
                Console.Write($"{cyfraSlownie} ");
            }
            Console.WriteLine();


            //zad2
            Mleko m = new Mleko();

            m.Cena = 10.0m;

            Promocja<Mleko> promocja = new Promocja<Mleko>();
            promocja.Produkt = m;
            promocja.wartosc = 30;
            Console.WriteLine(promocja.NowaCena());


            //zad 3
            System system = new System();
            Logger logger = new Logger();
            Aktywni aktywni = new Aktywni();
            system.Zalogowano += logger.GdyZalogowano;
            system.Zalogowano += aktywni.GdyZalogowano;
            system.login = "Daniel";
            system.haslo = "123";

            Console.WriteLine("Wpisz login:");
            string testlogin = Console.ReadLine();
            Console.WriteLine("Wpisz haslo:");
            string testhaslo = Console.ReadLine();

            system.Zaloguj(testlogin, testhaslo);

            Console.WriteLine("Logi:");
            foreach (string log in logger.logi)
            {
                Console.WriteLine(log);
            }



        }
    }
}

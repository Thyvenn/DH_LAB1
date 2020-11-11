using System;

namespace Zad4
{
    class Program
    {
        public class Ksiazka
        {
            public string tytul, autor;
            public int regal { get; set; }
            public int pulka { get; set; }
            public int miejsce { get; set; }

            public Ksiazka(int ksir, int ksip, int ksizm)
            {
                this.regal = ksir;
                this.pulka = ksip;
                this.miejsce = ksizm;
            }
        }


        static void Main(string[] args)
        {

            // Tu zmieniam regule zeby porownywanie znakow nie bylo restrykcyjne
            StringComparison comp = StringComparison.OrdinalIgnoreCase;

            // To mi bedzie potrzebne do sprawdzenia braku wyszukan
            int pozytywWyszukany = 0;

            // Dane od usera
            Console.WriteLine("Zmieniona ksiazka do 'Revan' autora 'Drew Karpyshyn' wpisz ciang znakow z autora albo nazwy ksiazki, to wpisze sie nazwa tej zmienionej ksiazki i jej pozycja w bibliotece:");
            string szukaj = Console.ReadLine();

            //towrzymy biblioteke 3D
            Ksiazka[,,] ksiazka = new Ksiazka[3, 6, 10];
            Ksiazka[,,] lib = ksiazka;


            for (int r = 0; r < lib.GetLength(0); r++)
            {
                for (int p = 0; p < lib.GetLength(1); p++)
                {
                    for (int m = 0; m < lib.GetLength(2); m++)
                    {
                        // Uzupelniamy biblioteke ksiazka z trylogi thrawna
                        Ksiazka ks1 = new Ksiazka(r + 1, p + 1, m + 1)
                        {
                            autor = "Timothy Zahn",
                            tytul = "Last Order"

                        };

                        //tutaj na tych koordach jest inna ksiazka

                        if (ks1.regal == 3 && ks1.pulka == 6 && ks1.miejsce == 9)
                        {
                            ks1.autor = "Drew Karpyshyn";
                            ks1.tytul = "Revan";
                        }

                        //tutaj warunek sprawdza to co napisalismy, czy zawiera to co chcemy jesli tak to wypisuje nam ksiazke
                        {

                            if (ks1.autor.Contains(szukaj, comp) || ks1.tytul.Contains(szukaj, comp))

                            {
                                pozytywWyszukany++;
                                Console.WriteLine($" Ksiazka: '{ks1.tytul}'  Autorstwa: '{ ks1.autor}'  Znajduje sie: R: { ks1.regal} P: {ks1.pulka} M: {ks1.miejsce}");
                            }

                        }
                    }
                }
            }

            //jezeli nie wyswietlila sie zadna ksiazka to pozytywWyszukany sie nie zwiekszy zatem sluzy za komunikat o braku ksiazki

            if (pozytywWyszukany == 0)
            {
                Console.WriteLine("Nie ma ksiazki w bibliotece zawierajacej takie znaki");
            }

        }
    }
}



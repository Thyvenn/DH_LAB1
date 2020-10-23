using System;
using System.Data;

namespace zad3
{
    class Program
    {
        //Sanitizer inputów na int
        static int Rein(string s_rein)
        {
            int rein_int;
            int i_timeout = 0;
            bool isint = int.TryParse(s_rein, out rein_int);
            while (!isint)
            {
                i_timeout++;
                if (i_timeout >= 3) break;

                Console.WriteLine($"Wykorzystales {i_timeout}/3 prób. Wpisz oczekiwana liczbe:");
                s_rein = Console.ReadLine();
                isint = int.TryParse(s_rein, out rein_int);

            }

            return rein_int;
        }
        static int[][] table1;
        static void Zad1()
        {
            Create_table();
            f_info_input();
            sumowanie();

            for (int i = 0; i < table1.GetLength(0); i++)
            {
                for (int j = 0; j < table1[i].GetLength(0); j++)
                {
                    Console.Write(table1[i][j] + " ");
                }
                Console.WriteLine();
            }
        }


        public static void Create_table()
        {
            Console.WriteLine("Ile ma byc wierszy?");

            string str1 = Console.ReadLine();
            int i_ile_wierszy = Rein(str1);


            table1 = new int[i_ile_wierszy][];

            for (int i = 0; i < i_ile_wierszy; i++)
            {
                Console.WriteLine($"Wpisz dlogość kolumny w wierszu nr:{i}");
                string s_kol = Console.ReadLine();
                int dlugosc_wiersza = Rein(s_kol);
                table1[i] = new int[dlugosc_wiersza];


            }
        }

        static void Manual()
        {
            for (int i = 0; i < table1.GetLength(0); i++)
            {
                for (int j = 0; j < table1[i].GetLength(0); j++)
                {
                    string cell = Console.ReadLine();
                    int i_cell = Rein(cell);

                    table1[i][j] = i_cell;
                }

            }


        }
        static void Automat()
        {
            Random rand = new Random();
            for (int i = 0; i < table1.GetLength(0); i++)
            {
                for (int j = 0; j < table1[i].GetLength(0); j++)
                {

                    table1[i][j] = rand.Next(1, 9);
                }

            }
        }
        static void sumowanie()
        {
            int i_suma = 0;
            for (int i = 0; i < table1.GetLength(0); i++)
            {
                for (int j = 0; j < table1[i].GetLength(0); j++)
                {

                    i_suma = i_suma + table1[i][j];
                }

            }
            Console.WriteLine(" ");

            Console.WriteLine($"Suma wynosi :{i_suma}");


        }

        static void f_info_input()
        {
            //iniclalizacja 

            Console.WriteLine("Chcesz podac liczby czy ma to zrobic automat ? \n 1)Ja podam liczby \n 2)Automat");

            string str = Console.ReadLine();
            int i_entcheidung = Rein(str);

            switch (i_entcheidung)
            {
                case 1:
                    Manual();
                    break;

                case 2:
                    Automat();
                    break;

                default:
                    Console.WriteLine("Zle dane");
                    break;
            }


        }

        static void Zad2()
            {

        string zdanie = Console.ReadLine();

        string erste = zdanie.Substring(0, 1);
        zdanie = erste.ToUpper() + zdanie.Substring(1);
            string dot = zdanie.Substring(zdanie.Length - 1);
            if(dot!=".")
            {
               zdanie = zdanie + '.';
            }

              Console.WriteLine(zdanie);
            }



        static void Main(string[] args)
        {

            Zad2();
            Zad1();



        }
    }
}
using System;
using System.ComponentModel.Design.Serialization;

namespace sanitizer
{
    class Program
    {

        static int Rein(string s_rein0)
        {
            int rein_int;
            int i_timeout = 0;
            bool isint = int.TryParse(s_rein0, out rein_int);
            while(!isint)
            {
                i_timeout++;
                if (i_timeout > 3) break;

                Console.WriteLine("Wpisz oczekiwana liczbe:");
                s_rein0 = Console.ReadLine();
                isint = int.TryParse(s_rein0, out rein_int);

            }

            return rein_int;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Chcesz:");
            string str1 = Console.ReadLine();

            int rein_int = Rein(str1);
            
            Console.WriteLine(rein_int);




        }
    }
}

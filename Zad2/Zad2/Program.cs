using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Z2
{
    class Program
    {

        enum MZerowe
        {
            Zero,
            Eins,
            Zwei,
        }


        static void Quadr(ref double a, ref double b, ref double c)
        {

            double delta = (b * b) - (4 * a * c);

            MZerowe m0 = 0;

            if (delta < 0) m0 = MZerowe.Zero;
            if (delta == 0) m0 = MZerowe.Eins;
            if (delta > 0) m0 = MZerowe.Zwei;

            switch (m0)
            {
                case MZerowe.Zero:
                    Console.WriteLine("Nie ma miejsc zerowych");
                    break;
                case MZerowe.Eins:
                    Console.WriteLine($"Jest miejsce zerowe bo delta= {delta} ");

                    break;
                case MZerowe.Zwei:
                    Console.WriteLine($"Są 2 miejsca zewrowe  bo delta= {delta} ");

                    break;
                default:
                    break;
            }


        }

        static double Nimmnum(string name)
        {

            double ver2;
            while (true)
            {
                Console.WriteLine($"Podaj parametr {name} funkcji:");

                string str = Console.ReadLine();

                bool istes = double.TryParse(str, out ver2);

                if (istes)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nocheinmal numer");
                }

            }
            return ver2;
        }


        static void Main(string[] args)
        {


            double a = Nimmnum("a");
            double b = Nimmnum("b");
            double c = Nimmnum("c");



            Quadr(ref a, ref b, ref c);
        }
    }
}

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;

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
            double sqr_delta = Math.Sqrt(delta);
            double mzloc1 = (-b - sqr_delta) / (2 * a);
            double mzloc2 = (-b + sqr_delta) / (2 * a);

            MZerowe m0 = 0;

            if (delta < 0) m0 = MZerowe.Zero;
            else if (delta == 0) m0 = MZerowe.Eins;
            else m0 = MZerowe.Zwei;

            switch (m0)
            {
                case MZerowe.Zero:
                    Console.WriteLine("Nie ma miejsc zerowych");
                    break;
                case MZerowe.Eins:
                    Console.WriteLine($"Jest miejsce zerowe w x={mzloc1} bo delta= {delta} ");

                    break;
                case MZerowe.Zwei:
                    Console.WriteLine($"Są 2 miejsca zewrowe w x1={mzloc1} i w x2={mzloc2} bo delta= {delta} ");

                    break;
                default:
                    break;
            }


        }

        static double Nimmnum(string name)
        {

            double ver2;
            int i_timeout = 0;
          
                Console.WriteLine($"Podaj parametr {name} funkcji:");

                string str = Console.ReadLine();

                bool istes = double.TryParse(str, out ver2);

            while (!istes)
            {
                Console.WriteLine("Jeszcze raz podaj nr");

                str = Console.ReadLine();
                istes = double.TryParse(str, out ver2);

                if (i_timeout > 4)
                {
                    Console.WriteLine("Za duzo prob, do widzenia wylanczam program"); ;
                    Thread.Sleep(4000);
                    System.Environment.Exit(1);

                }
                i_timeout++;
            
            }
            i_timeout = 0;
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

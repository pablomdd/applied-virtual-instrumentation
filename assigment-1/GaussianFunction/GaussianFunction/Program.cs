using System;

namespace GaussianFunction
{
    class Program
    {
        static double Gauss(double x, double m = 0, double s = 1)
        {
            return 1 / (s * Math.Sqrt(2 * Math.PI)) * Math.Exp(-0.5 * Math.Pow((x - m) / s, 2));
        }

        static void printTable(double m = 2, double s = 2)
        {
            Console.WriteLine("x \t f(x)");
            for (var x = m - 5 * s; x <= m + 5 * s; ++x)
            {
                Console.WriteLine(x + "\t" + Gauss(x, m, s));
            }
        }
        static void Main(string[] args)
        {
            printTable(0, 1);
        }
    }
}

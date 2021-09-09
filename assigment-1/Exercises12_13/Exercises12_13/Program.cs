using System;

namespace Exercises12_13
{
    class Program
    {
        static double PathLength(double[] x, double[] y)
        {
            double length = 0.0;
            for(int i = 1; i < x.Length; ++i)
            {
                length += Math.Sqrt(Math.Pow(x[i] - x[i - 1], 2) + Math.Pow(y[i] - y[i - 1], 2));
            }
            return length;
        }

        static void TestPathLength()
        {
            double L2 = 5;
            bool expectedResult = true;

            double[] x = new double[] { 0, 3 };
            double[] y = new double[] { 0, 4 };
            Console.WriteLine("Expect test to be " + expectedResult);
            Console.WriteLine("Test Result is: " + (PathLength(x, y) == L2));
        }

        static (double[] x, double[] y) PiApprox(int n)
        {
            double[] x = new double[n];
            double[] y = new double[n];

            for(int i = 0; i < n; ++i)
            {
                x[i] = Math.Cos(2 * Math.PI * i / n);
                y[i] = Math.Sin(2 * Math.PI * i / n);
            }
            return (x, y);
        }

        static void testPiApprox()
        {
            const int testLimit = 10;
            for(int k = 2; k <= testLimit; ++k)
            {
                int n = Convert.ToInt32(Math.Pow(2, k));
                (double[] x, double[] y) = PiApprox(n);
                double piApprox = PathLength(x, y);
                double error = Math.PI - piApprox;
                Console.WriteLine("With " + n + " point the error is " + error);
            }
        }
        static void Main(string[] args)
        {
            testPiApprox();
        }
    }
}

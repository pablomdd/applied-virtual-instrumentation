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
        static void Main(string[] args)
        {
            TestPathLength();
        }
    }
}

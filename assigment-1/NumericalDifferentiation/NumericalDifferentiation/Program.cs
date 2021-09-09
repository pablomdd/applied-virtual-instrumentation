using System;
using System.Collections.Generic;

namespace NumericalDifferentiation
{
    class Program
    {
        static double Diff(Func<double, double> f,double x, double h = 0.00001)
        {
            return (f(x + h) - f(x - h)) / (2 * h);
        }
        static void test_diff()
        {
            Console.WriteLine("============ Test Diff ============");
            Console.WriteLine("Expect test comparison to be True.");
            Func<double, double> square = x => x*x;
            double expectedRes = 2.0;
            Console.WriteLine("Test result: " + ((Diff(square, 1) - expectedRes) < 0.0000000001));
        }
        static void application()
        {
            Console.WriteLine("============ Application ============");
            Func<double, double> exp2 = x => Math.Exp(-2 * Math.Pow(x, 2));
            Dictionary<string, (Func<double, double>, double, double)> dict = new Dictionary<string, (Func<double, double>, double, double)>();
            dict.Add("e^x", (Math.Exp, 0, 0));
            dict.Add("e^(-2x^2)", (exp2, 0, 0));
            dict.Add("cos(x)", (Math.Cos, 2 * Math.PI, 0));
            dict.Add("ln(x)", (Math.Log, 1, 0));
            Console.WriteLine("f(x) \t\tx   \t\tf'(x)  \t\tdiff(x) \t\tError");
            foreach (var kvp in dict)
            {
                var (f, x, res) = kvp.Value;
                var diff = Diff(f, x);
                var error = diff - res;
                Console.WriteLine(kvp.Key + "\t\t" + x + "\t\t" + res + "\t\t" + diff + "\t\t" + error);

            }
        }
        static void Main(string[] args)
        {
            test_diff();
            application();
        }
    }
}

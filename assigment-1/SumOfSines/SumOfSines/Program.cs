using System;

namespace SumOfSines
{
    class Program
    {
        static double S(double t, int n, double T)
        {
            double sum = 0.0;
            for(int i = 0; i < n; ++i)
            {
                sum += 1 / (2 * i - 1) * Math.Sin((2 * (2 * i - 1) * t * Math.PI) / T);
            } 
            return sum * 4 / Math.PI;
        }

        static double F_t(double t, double T)
        {
            if (0 < t && t < T / 2) return 1.0;
            else if (Math.Abs(t - T / 2) < Math.Exp(-14)) return 0.0;
            else return -1.0;
        }

        static private void printErrorTable()
        {
            int[] nList = new int[] { 1, 3, 5, 10, 30, 100 };
            double[] alphaList = new double[] { 0.01, 0.25, 0.49 };
            double T = 2 * Math.PI;
            double[] tList = new double[alphaList.Length];
            for(int i = 0; i < alphaList.Length; ++i)
            {
                tList[i] = 2 * T * alphaList[i];
            }
            foreach(int n in nList)
            {
                Console.WriteLine("n=" + n + "\t\tS(t, n, T)\t\tf(t, T)\t\t\tError");
                foreach (var t in tList)
                {
                    var fourier = S(t, n, T);
                    var sinApprox = F_t(t, T);
                    var error = sinApprox - fourier;
                    Console.WriteLine("\t\t" + fourier + "\t\t" + sinApprox + "\t\t" + error);
                }
                Console.WriteLine("");
            }
        }
        static void Main(string[] args)
        {
            printErrorTable();
        }
    }
}

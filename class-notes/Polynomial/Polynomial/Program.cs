using System;

namespace Polynomial
{
    class  Polynomial
    {
        public readonly double[] coeff;
        string s;

        public Polynomial(double[] coeff)
        {
            this.coeff = coeff;
        }

        public double Eval(double x)
        {
            double result = 0;
            for(int i = 0; i < coeff.Length; ++i)
            {
                result += coeff[i] * Math.Pow(x, i);
            }
            return result;
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            double[] result;
            result = new double[Math.Max(a.coeff.Length, b.coeff.Length)];
            if (a.coeff.Length > b.coeff.Length)
            {
                for(int i = 0; i < a.coeff.Length; ++i)
                {
                    result[i] = a.coeff[i];
                }
                for (int i = 0; i < b.coeff.Length; ++i)
                {
                    result[i] += b.coeff[i];
                }
            } else
            {
                for (int i = 0; i < b.coeff.Length; ++i)
                {
                    result[i] = b.coeff[i];
                }
                for (int i = 0; i < a.coeff.Length; ++i)
                {
                    result[i] += a.coeff[i];
                }
            }
            Console.WriteLine(result);
            return new Polynomial(result);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double[] cp1 = new double[] { 1, -1 };
            Polynomial p1 = new Polynomial(cp1);
            double[] cp2 = new double[] { 0, 1, 0, 0, -6, -1 };
            Polynomial p2 = new Polynomial(cp1);

            Console.WriteLine("p1(2)= " + p1.Eval(2));
            Console.WriteLine("p2(1)= " + p2.Eval(1));
            Console.WriteLine("p1+p2= " + (p1 + p2));

        }
    }
}

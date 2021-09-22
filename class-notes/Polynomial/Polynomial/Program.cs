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

        public static String ShowCoeff(Polynomial p)
        {
            String r = "[";
            for(int i = 0; i < p.coeff.Length; ++i)
            {
                r += p.coeff[i] + " + ";
            }
            r += p.coeff[p.coeff.Length - 1] + "]";
            return r;
        }
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            double[] c = new double[a.coeff.Length];
            for (int i = 0; i < a.coeff.Length; ++i)
            {
                c[i] = a.coeff[i];
            }
            double[] d = new double[b.coeff.Length];
            for (int i = 0; i < b.coeff.Length; ++i)
            {
                d[i] = b.coeff[i];
            }
            int M = c.Length - 1;
            int N = d.Length - 1;
            double[] resultCoeff = new double[M + N + 1];
            for (int i = 0; i < resultCoeff.Length; ++i)
            {
                resultCoeff[i] = 0;
            }
            for (int i = 0; i < M + 1; ++i)
            {
                for (int j = 0; j < N + 1; ++j)
                {
                    resultCoeff[i + j] += c[i] * d[j];
                }
            }

            return new Polynomial(resultCoeff);
        }

        private double[] Differentiate(Polynomial a)
        {
            double[] result = new double[a.coeff.Length];
            for (int i = 0; i < a.coeff.Length; ++i)
            {
                result[i] = a.coeff[i];
            }
            for (int i = 1; i < result.Length; ++i)
            {
                result[i - 1] = i * result[i]; 
            }
            Array.Resize(ref result, result.Length - 1);
            return result;
        }

        public Polynomial Derivative()
        {
            double[] cd = new double[this.coeff.Length];
            for(int i = 0; i < this.coeff.Length; ++i)
            {
                cd[i] = this.coeff[i];
            }
            Polynomial e = new Polynomial(cd);
            double[] result;
            result = Differentiate(e);
            return new Polynomial(result);
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
        public override string ToString()
        {
            s = "";
            for (int i = 0; i < this.coeff.Length; ++i)
            {
                if(this.coeff[i] != 0.0)
                {
                    s += " + " + this.coeff[i] + "*x^" + i;
                }
            }
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double[] cp1 = new double[] { 1, -1 };
            Polynomial p1 = new Polynomial(cp1);
            double[] cp2 = new double[] { 0, 1, 0, 0, -6, -1 };
            Polynomial p2 = new Polynomial(cp2);

            Console.WriteLine("p1(2)= " + Polynomial.ShowCoeff(p1));
            Console.WriteLine("p2(1)= " + p2.Eval(1));
            Console.WriteLine("p1+p2= " + (p1 + p2).Eval(2));
            Console.WriteLine("p1*p2= " + (p1 * p2).Eval(3));
            Polynomial p5 = p2.Derivative();
            Console.WriteLine("p5 = dp2/dx = " + Polynomial.ShowCoeff(p5));
            Console.WriteLine(p2);
        }
    }
}

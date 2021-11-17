using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace rootsQuadraticFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, r1, r2;

            Console.WriteLine("Raíces de una ecuación cuadrática:");

            try
            {
                Console.WriteLine("Ingresa el coeficiente a: ");
                a = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingresa el coeficiente b: ");
                b = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingresa el coeficiente c: ");
                c = Convert.ToDouble(Console.ReadLine());

                r1 = (-b + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
                r2 = (-b - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);

                if (Double.IsNaN(r1) == false || Double.IsNaN(r2) == false)
                {
                    Console.WriteLine("La primera raiz es: {0}", r1.ToString("F5"));
                    Console.WriteLine("La segunda raiz es: {0}", r2.ToString("F5"));
                }
                else
                {
                    Console.WriteLine("Las raíces son imaginarias, ingresa los coeficientes imaginarios:");

                    Complex ai, bi, ci, r1i, r2i;

                    try
                    {
                        ai = new Complex(a, 0);
                        bi = new Complex(b, 0);
                        ci = new Complex(c, 0);
                        r1i = (-bi + Complex.Sqrt(Complex.Pow(bi, 2) - (4 * ai * ci))) / (2 * ai);
                        r2i = (-bi - Complex.Sqrt(Complex.Pow(bi, 2) - (4 * ai * ci))) / (2 * ai);
                        Console.WriteLine("La primera raiz es: {0}", r1i.ToString("F5"));
                        Console.WriteLine("La segunda raiz es: {0}", r2i.ToString("F5"));
                    }
                    catch
                    {
                        Console.WriteLine("Error con los datos ingresados.");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error con los datos ingresados.");
            }
        }
    }
}
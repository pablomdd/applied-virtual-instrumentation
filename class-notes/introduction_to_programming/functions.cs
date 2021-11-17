using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace funciones
{
    class IntroFunciones
    {
        static void ImprimirHola()
        {
            Console.WriteLine("Hola!");
        }
        static void ImprimirSumarArgumentos(String arg1, String arg2)
        {
            Console.WriteLine(arg1 + arg2);
        }
        static void ImprimirSumarArgumentos(int arg1, int arg2)
        {
            Console.WriteLine(arg1 + arg2);
        }
        static void ImprimirSumarArgumentos(double arg1, double arg2)
        {
            Console.WriteLine(arg1 + arg2);
        }
        static void ImprimirSumarArgumentos(Complex arg1, Complex arg2)
        {
            Console.WriteLine(arg1 + arg2);
        }
        static double RegresarPi()
        {
            return Math.PI;
        }
        static String multipliplica_A_y_B(int repetir, String arg)
        {
            String result = "";
            for (int i = 0; i < repetir; i++)
            {
                result = result + arg;
            }
            return result;
        }
        static Complex multiplicica_A_y_B(Complex c1, Complex c2)
        {
            Complex result;
            return result = c1 * c2;
        }
        static void Main(string[] args)
        {
            ImprimirHola();

            ImprimirSumarArgumentos("¡Hola", " Mundo!");
            ImprimirSumarArgumentos(1, 2);
            ImprimirSumarArgumentos(1.0, 2.0);

            Complex a_c = new Complex(1, 2);
            Complex b_c = new Complex(1, 2);
            ImprimirSumarArgumentos(a_c, b_c);

            double areaCirculo = RegresarPi() * Math.Pow(1, 2);
            Console.WriteLine("El área del circulo unitario es: {0} y un número complejo es: {1}", areaCirculo, a_c);

            String var_resultado_multiplicacion_1 = multiplicica_A_y_B(2, "Hola");
            Console.WriteLine(var_resultado_multiplicacion_1);

            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(1, -1);
            Complex var_resultado_multiplicacion_2 = multiplicica_A_y_B(c1, c2);
            Console.WriteLine(var_resultado_multiplicacion_2);
        }
    }
}
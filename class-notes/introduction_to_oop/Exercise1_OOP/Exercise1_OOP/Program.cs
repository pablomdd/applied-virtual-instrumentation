using System;

namespace Exercise1_OOP
{
    class Y
    {
        // Variables de instancia
        public double y0;
        public double v0;
        public double g;

        // Constructor
        public Y(double y0, double v0)
        {
            this.y0 = y0;
            this.v0 = v0;
            this.g = 9.81;
        }

        public double Value(double t)
        {
            return y0 + v0 * t + 0.5 * g * Math.Pow(t, 2);
        }

        public void Formula()
        {
            Console.WriteLine("y = {0} + {1}*t + 0.5*{2}*t^2", y0, v0, g);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double y0 = 10;
            double v0 = 5;
            double t = 15;

            Y Yee = new Y(y0, v0);
            Console.WriteLine(Yee.Value(t));
            Console.WriteLine(Yee.y0);
            Yee.Formula();
        }
    }
}

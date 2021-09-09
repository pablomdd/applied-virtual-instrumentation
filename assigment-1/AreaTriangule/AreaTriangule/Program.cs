using System;


namespace AreaTriangule
{
    class Program
    {
        static double areaTriangule((int x, int y) v1, (int x, int y) v2, (int x, int y) v3)
        {
            double area = 0.5 * Math.Abs(v2.x * v3.y - v3.x * v2.y - v3.x * v2.y - v3.x * v2.y - 
                v1.x * v3.y + v3.x * v1.y + v1.x * v2.y -v2.x * v1.y);
            return area;
        }
        static void Main(string[] args)
        {
            (int x, int y) v1 = (0, 0);
            (int x, int y) v2 = (1, 0);
            (int x, int y) v3 = (0, 2);

            Console.WriteLine(areaTriangule(v1, v2, v3));
        }
    }
}

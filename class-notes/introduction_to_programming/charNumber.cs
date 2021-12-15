using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//El código se corre dando clic en CTRL + F5
namespace Ejercicio7
{
    class CaracteresString
    {
        static void Main(string[] args)
        {
            string s = "numero de caracteres en string";
            Dictionary<string, int> dict = new Dictionary();

            foreach (var c in s.Length)
            {
                if (dict.Contains(c))
                {
                    dict[c] += 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                Console.WriteLine("El caracter {0} aparece {1} veces.", kvp.Key, kvp.Value);
            }
        }
    }
}
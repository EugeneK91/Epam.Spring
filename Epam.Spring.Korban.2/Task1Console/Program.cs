using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var power = 2;
            var value = 15823;
            var rootValue = CalculateRoot.GetRootByNewtonMethod(value, power);
            var restoredValue = Math.Pow(rootValue, 2);
            Console.WriteLine("Корень числа методом Ньютона: " + rootValue);
            Console.WriteLine("Результат сравнения исходного значения {0} с восттановленным значением {1}: {2}", value, restoredValue, CalculateRoot.ValidateRootNewtonMethod(value,restoredValue));
        }
    }
}

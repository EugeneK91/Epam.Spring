using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            double runtime;
            Console.WriteLine("Вычисление НОДа методом Евклида для 2-ух параметров: {0} время {1}мс", CalculateGDC.GetEvklidNod(132, 18, out runtime), runtime);
            Console.WriteLine("Вычисление НОДа методом Евклида для 3-ех параметров: {0} время {1}мс",CalculateGDC.GetEvklidGDC(132, 18, 48, out runtime), runtime);
            Console.WriteLine("Вычисление НОДа методом Стеина для 2-ух параметров: {0} время {1}мс", CalculateGDC.GetSteinGDC(132, 18, out runtime), runtime);
            Console.WriteLine("Вычисление НОДа методом Стеина для 3-ух параметров: {0} время {1}мс",CalculateGDC.GetSteinGDC(132, 18, 48, out runtime), runtime);
        }
    }
}

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
            int intVal = 456;
            long longVal = 101;
            uint uintVal = 8585;

            Console.WriteLine("Show int value {0} to hex: {1}", intVal,intVal.ViewToHex());
            Console.WriteLine("Show long value {0} to hex: {1}", longVal, longVal.ViewToHex());
            Console.WriteLine("Show uint value {0} to hex: {1}", uintVal, uintVal.ViewToHex());
        }
    }
}

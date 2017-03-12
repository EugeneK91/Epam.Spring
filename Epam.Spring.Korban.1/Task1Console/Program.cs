using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] {10, 12, 5, 6, 20, 2, 1, 6, 6};
            Console.WriteLine("Max value: " + MaximumElementOfArray.GetMaxElementFromArray(arr,arr[0]));
        }
    }
}

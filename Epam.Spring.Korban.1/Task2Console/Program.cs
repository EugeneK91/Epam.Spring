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
            var arr = new[] {1, 2, 3, 4, 5, 4, 3, 2, 1};
            Console.WriteLine("Specific index: " + SpecificIndex.GetSpecificIndex(arr));
        }
    }
}

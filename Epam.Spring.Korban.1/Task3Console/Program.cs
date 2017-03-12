using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3Logic;

namespace Task3Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 1, 4, 3, 6 };
            Console.WriteLine("Sorted array: " + string.Join(",", MergeSort.Sort(arr)));
        }
    }
}

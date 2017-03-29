using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1Logic;

namespace Task1Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] {4,45,3,2,1,5,34};
            MergeSort.SortMerge(array);
            foreach (int t in array)
                Console.Write(t+" ");
            Console.ReadLine();
        }
    }
}

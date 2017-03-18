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
            var arr = new int[][] { new int[]{9,3,5,6},new int[]{1,2,3,4,5},new []{2,5,15} };
            SortMultiArray.SortArray(arr,TypeSortEnum.AscendingSorBySumElements);
            SortMultiArray.ShowArray(arr);

            SortMultiArray.SortArray(arr, TypeSortEnum.DescendingSorByMaxElements);
            SortMultiArray.ShowArray(arr);

            SortMultiArray.SortArray(arr, TypeSortEnum.AscendingSorByMinElements);
            SortMultiArray.ShowArray(arr);
        }
    }
}

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
            var arr = new int[][] { new int[]{9,3,5,6},new int[]{1,2,12},new []{2,5,15} };
            SortMultiArray.BubleSortArray(arr,TypeSortEnum.AscendingSorBySumElements);
            SortMultiArray.ShowArray(arr);

            SortMultiArray.BubleSortArray(arr, TypeSortEnum.DescendingSorBySumElements);
            SortMultiArray.ShowArray(arr);

            SortMultiArray.BubleSortArray(arr, TypeSortEnum.AscendingSorByMinElements);
            SortMultiArray.ShowArray(arr);

            SortMultiArray.BubleSortArray(arr, TypeSortEnum.DescendingSorByMinElements);
            SortMultiArray.ShowArray(arr);

            SortMultiArray.BubleSortArray(arr, TypeSortEnum.AscendingSorByMaxElements);
            SortMultiArray.ShowArray(arr);

            SortMultiArray.BubleSortArray(arr, TypeSortEnum.DescendingSorByMaxElements);
            SortMultiArray.ShowArray(arr);
        }
    }
}

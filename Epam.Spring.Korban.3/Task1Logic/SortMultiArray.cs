using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class SortMultiArray
    {
        public static void SortArray(int[][] arr, TypeSortEnum typeSort)
        {
            switch (typeSort)
            {
                case TypeSortEnum.AscendingSorBySumElements:
                    SortStringsArrayBySumElements(arr, AscDescSort.Ascending);
                    break;
                case TypeSortEnum.DescendingSorBySumElements:
                    SortStringsArrayBySumElements(arr, AscDescSort.Descending);
                    break;
                case TypeSortEnum.AscendingSorByMaxElements:
                    SortStringsArrayByMaxElements(arr,AscDescSort.Ascending);
                    break;
                case TypeSortEnum.DescendingSorByMaxElements:
                    SortStringsArrayByMaxElements(arr, AscDescSort.Descending);
                    break;
                case TypeSortEnum.AscendingSorByMinElements:
                    SortStringsArrayByMinElements(arr, AscDescSort.Ascending);
                    break;
                case TypeSortEnum.DescendingSorByMinElements:
                    SortStringsArrayByMinElements(arr, AscDescSort.Descending);
                    break;
            }
        }

        public static void ShowArray(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("arr[{0}]: ",i);
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + ",");
                }
                Console.WriteLine();
            }           
        }

        private static void SortStringsArrayBySumElements(int[][] arr,AscDescSort typeSort)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                for (var k = i + 1; k < arr.Length; k++)
                {
                    var sum1 = 0;

                    for (var j = 0; j < arr[i].Length; j++)
                    {
                        sum1 += arr[i][j];
                    }

                    var sum2 = 0;
                    for (var t = 0; t < arr[k].Length; t++)
                    {
                        sum2 += arr[k][t];
                    }
                    if (typeSort == AscDescSort.Ascending)
                    {
                        if (sum1 > sum2)
                        {
                            ReplaceArrayElements(arr, i, k);
                        }
                    }
                    else
                    {
                        if (sum1 < sum2)
                        {
                            ReplaceArrayElements(arr, i, k);
                        }                     
                    }
                }
            }        
        }

        private static void SortStringsArrayByMaxElements(int[][] arr, AscDescSort typeSort)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                for (var k = i + 1; k < arr.Length; k++)
                {
                    var maxElement1 = GetMaxElement(arr,i);

                    var maxElement2 = GetMaxElement(arr, k);
                    if (typeSort == AscDescSort.Ascending)
                    {
                        if (maxElement1 > maxElement2)
                        {
                            ReplaceArrayElements(arr, i, k);
                        }
                    }
                    else
                    {
                        if (maxElement1 < maxElement2)
                        {
                            ReplaceArrayElements(arr, i, k);
                        }
                    }
                }
            }
        }

        private static void SortStringsArrayByMinElements(int[][] arr, AscDescSort typeSort)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                for (var k = i + 1; k < arr.Length; k++)
                {
                    var maxElement1 = GetMinElement(arr, i);

                    var maxElement2 = GetMinElement(arr, k);
                    if (typeSort == AscDescSort.Ascending)
                    {
                        if (maxElement1 > maxElement2)
                        {
                            ReplaceArrayElements(arr, i, k);
                        }
                    }
                    else
                    {
                        if (maxElement1 < maxElement2)
                        {
                            ReplaceArrayElements(arr, i, k);
                        }
                    }
                }
            }
        }

        private static void ReplaceArrayElements(int[][] arr,int firstIndex,int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        private static int GetMaxElement(int[][]a,int index)
        {
            int max = a[index][0];
            for (int i = 0; i < a[index].Length; i++)
            {
                if (a[index][i] > max)
                {
                    max = a[index][i];
                }
            }
            return max;
        }

        private static int GetMinElement(int[][] a, int index)
        {
            int min = a[index][0];
            for (int i = 0; i < a[index].Length; i++)
            {
                if (a[index][i] < min)
                {
                    min = a[index][i];
                }
            }
            return min;
        }
    }
}

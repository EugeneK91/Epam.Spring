using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    /// <summary>
    /// Provides functionality for sort multiarray
    /// </summary>
    public class SortMultiArray
    {
        #region Public Methods
        /// <summary>
        /// Sorts an array depending on the type
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="typeSort">type of sort</param>
        public static void BubleSortArray(int[][] arr, TypeSortEnum typeSort)
        {
            if (arr == null)
            {
                throw new ArgumentException("array");
            }
            switch (typeSort)
            {
                case TypeSortEnum.AscendingSorBySumElements:
                    SortStringsArrayBySumElements(arr, AscDescSort.Ascending);
                    break;
                case TypeSortEnum.DescendingSorBySumElements:
                    SortStringsArrayBySumElements(arr, AscDescSort.Descending);
                    break;
                case TypeSortEnum.AscendingSorByMaxElements:
                    SortStringsArrayByMaxElement(arr,AscDescSort.Ascending);
                    break;
                case TypeSortEnum.DescendingSorByMaxElements:
                    SortStringsArrayByMaxElement(arr, AscDescSort.Descending);
                    break;
                case TypeSortEnum.AscendingSorByMinElements:
                    SortStringsArrayByMinElement(arr, AscDescSort.Ascending);
                    break;
                case TypeSortEnum.DescendingSorByMinElements:
                    SortStringsArrayByMinElement(arr, AscDescSort.Descending);
                    break;
            }
        }

        /// <summary>
        /// Show array
        /// </summary>
        /// <param name="arr">array</param>
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
            Console.WriteLine();
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Sort an array by sum of string elements
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="typeSort">type of sort: may be ascending or descending</param>
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


        /// <summary>
        /// sort array strings in an array by max element of string 
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="typeSort">type of sort: may be ascending or descending</param>
        private static void SortStringsArrayByMaxElement(int[][] arr, AscDescSort typeSort)
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

        /// <summary>
        /// sort array strings in an array by min element of string 
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="typeSort">type of sort: may be ascending or descending</param>
        private static void SortStringsArrayByMinElement(int[][] arr, AscDescSort typeSort)
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

        /// <summary>
        /// replace  elements of array
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="firstIndex">arr index of subarray</param>
        /// <param name="secondIndex">arr index of subarray</param>
        private static void ReplaceArrayElements(int[][] arr,int firstIndex,int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        /// <summary>
        /// Get max element of array
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="index">index of subarrray</param>
        /// <returns></returns>
        private static int GetMaxElement(int[][]arr,int index)
        {
            int max = arr[index][0];
            for (int i = 0; i < arr[index].Length; i++)
            {
                if (arr[index][i] > max)
                {
                    max = arr[index][i];
                }
            }
            return max;
        }

        /// <summary>
        /// Get min element of array
        /// </summary>
        /// <param name="arr">array</param>
        /// <param name="index">index of subarrray</param>
        /// <returns></returns>
        private static int GetMinElement(int[][] arr, int index)
        {
            int min = arr[index][0];
            for (int i = 0; i < arr[index].Length; i++)
            {
                if (arr[index][i] < min)
                {
                    min = arr[index][i];
                }
            }
            return min;
        }
        #endregion 
    }
}

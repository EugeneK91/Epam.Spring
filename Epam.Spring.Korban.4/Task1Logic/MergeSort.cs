using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class MergeSort
    {

        #region Public Methods

        /// <summary>
        /// Method that call merge sort
        /// </summary>
        /// <param name="array">sortable array</param>
        static public void SortMerge(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Method that process sort
        /// </summary>
        /// <param name="array"> sortable array</param>
        /// <param name="left">left border of array</param>
        /// <param name="right">right border of array</param>
        static private void Sort(int[] array, int left, int right)
        {
            if (right > left)
            {
                var mid = (right + left) / 2;
                Sort(array, left, mid);
                Sort(array, (mid + 1), right);

                Merge(array, left, (mid + 1), right);
            }
        }

        /// <summary>
        /// Method that merge first subarray with seconf subarray 
        /// </summary>
        /// <param name="array">sortable array</param>
        /// <param name="left">left border of array</param>
        /// <param name="mid">middle of array</param>
        /// <param name="right">right border of array</param>
        static private void Merge(int[] array, int left, int mid, int right)
        {
            var temp = new int[array.Length];
            var leftEnd = (mid - 1);
            var tmpPos = left;
            var numElements = (right - left + 1);

            while ((left <= leftEnd) && (mid <= right))
            {
                if (array[left] <= array[mid])
                    temp[tmpPos++] = array[left++];
                else
                    temp[tmpPos++] = array[mid++];
            }

            while (left <= leftEnd)
                temp[tmpPos++] = array[left++];

            while (mid <= right)
                temp[tmpPos++] = array[mid++];

            for (var i = 0; i < numElements; i++)
            {
                array[right] = temp[right];
                right--;
            }
        }
        #endregion
    }
}
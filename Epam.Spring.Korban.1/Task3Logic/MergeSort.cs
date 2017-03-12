using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Logic
{
    public class MergeSort
    {
        public static int[] Sort(int[] massive)
        {
            if (massive.Length == 1)
                return massive;
            int mid_point = massive.Length / 2;
            return Merge(Sort(massive.Take(mid_point).ToArray()), Sort(massive.Skip(mid_point).ToArray()));
        }
        private static int[] Merge(int[] leftArr, int[] rightArr)
        {
            int leftIndex = 0, rightIndex = 0;
            var mergedArr = new int[leftArr.Length + rightArr.Length];
            for (int i = 0; i < leftArr.Length + rightArr.Length; i++)
            {
                if (rightIndex < rightArr.Length && leftIndex < leftArr.Length)
                    if (leftArr[leftIndex] > rightArr[rightIndex] && rightIndex < rightArr.Length)
                        mergedArr[i] = rightArr[rightIndex++];
                    else
                        mergedArr[i] = leftArr[leftIndex++];
                else
                    if (rightIndex < rightArr.Length)
                        mergedArr[i] = rightArr[rightIndex++];
                    else
                        mergedArr[i] = leftArr[leftIndex++];
            }
            return mergedArr;
        }
    }
}

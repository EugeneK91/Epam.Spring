using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    public class SpecificIndex
    {
        public static int GetSpecificIndex(int[] arr)
        {
            for (var i = 1; i < arr.Length-1; i++)
            {
                var leftSum = GetLeftSum(arr,i);
                var rightSum = GetRightSum(arr, i);
                if (leftSum == rightSum) return i;
            }
            return -1;
        }

        private static int GetLeftSum(int[] arr,int index)
        {
            ValidateArray(arr);
            return arr.Take(index).Sum();
        }

        private static int GetRightSum(int[] arr, int index)
        {
            ValidateArray(arr);
            return arr.Skip(index+1).Sum();
        }

        private static void ValidateArray(int[] arr)
        {
            if (arr == null)
            {
                throw new Exception("arr is null");
            }
        }
    }

}

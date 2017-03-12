using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class MaximumElementOfArray
    {
        public static int GetMaxElementFromArray(int[] arr,int maxValue,int index=0)
        {
            if (arr == null)
            {
                throw new ArgumentException("arr is null");
            }

            if (arr.Length == index)
                return maxValue;
           return GetMaxElementFromArray(arr, arr[index]>maxValue?arr[index]:maxValue, index+1);
        }
    }
}

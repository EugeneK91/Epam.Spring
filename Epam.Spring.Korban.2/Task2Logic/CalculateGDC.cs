using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Task2Logic
{
    /// <summary>
    /// logic for compute GDC
    /// </summary>
    public class CalculateGDC
    {

        #region Public Methods
        /// <summary>
        /// Method that returned GDC for 2 values by Evklid algorithm
        /// </summary>
        /// <param name="firstValue">first value for compute of GDC</param>
        /// <param name="secondValue">second value for compute of GDC</param>
        /// <param name="runTime">return runtime of method</param>
        /// <returns></returns>
        public static int GetEvklidNod(int firstValue, int secondValue, out double runTime)
        {
            Func<int, int, int> method = CalculateGDCByEvklidAlgorithm;
            var result = ComputerTime(firstValue, secondValue, method, out runTime);
            return result;
        }

        /// <summary>
        /// Method that returned GDC for 2 values by Evklid algorithm
        /// </summary>
        /// <param name="firstValue">first value for compute of GDC</param>
        /// <param name="secondValue">second value for compute of GDC</param>
        /// <param name="thirdvalue">third value for compute of GDC</param>
        /// <param name="runTime">return runtime of method</param>
        /// <returns></returns>
        public static int GetEvklidGDC(int firstValue, int secondValue, int thirdvalue, out double runTime)
        {
            Func<int, int, int,int> method = CalculateGDCByEvklidAlgorithm;
            var result = ComputerTime(firstValue, secondValue,thirdvalue, method, out runTime);
            return result;
        }

        /// <summary>
        /// Method that returned GDC for 2 values by Stein's algorithm
        /// </summary>
        /// <param name="firstValue">first value for compute of GDC</param>
        /// <param name="secondValue">second value for compute of GDC</param>
        /// <param name="runTime">return runtime of method</param>
        /// <returns></returns>
        public static int GetSteinGDC(int firstValue, int secondValue, out double runTime)
        {
            Func<int, int, int> method = CalculateGDCBySteinsAlgorithm;
            var result = ComputerTime(firstValue, secondValue, method, out runTime);
            return result;
        }

        /// <summary>
        /// Method that returned GDC for 3 values by Stein's algorithm
        /// </summary>
        /// <param name="firstValue">first value for compute of GDC</param>
        /// <param name="secondValue">second value for compute of GDC</param>
        /// <param name="thirdvalue">second value for compute of GDC</param>
        /// <param name="runTime">return runtime of method</param>
        /// <returns></returns>
        public static int GetSteinGDC(int firstValue, int secondValue, int thirdvalue, out double runTime)
        {
            Func<int, int, int,int> method = CalculateGDCBySteinsAlgorithm;
            var result = ComputerTime(firstValue, secondValue,thirdvalue, method, out runTime);
            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method that compute GDC for 2 values by Evklid algorithm
        /// </summary>
        /// <param name="firstValue">first value for compute of GDC</param>
        /// <param name="secondValue">second value for compute of GDC</param>
        /// <returns></returns>
        private static int CalculateGDCByEvklidAlgorithm(int firstValue, int secondValue)
        {
            while (firstValue != 0)
                firstValue = secondValue % (secondValue = firstValue);
            return secondValue;
        }

        /// <summary>
        /// Method that compute GDC for 3 values by Evklid algorithm
        /// </summary>
        /// <param name="firstValue">first value for compute of GDC</param>
        /// <param name="secondValue">second value for compute of GDC</param>
        /// <param name="thirdvalue">third value for compute of GDC</param>
        /// <returns></returns>
        private static int CalculateGDCByEvklidAlgorithm(int firstValue, int secondValue,int thirdvalue)
        {
            return  CalculateGDCByEvklidAlgorithm(thirdvalue, CalculateGDCByEvklidAlgorithm(firstValue, secondValue));
        }

        /// <summary>
        /// Method that compute GDC for 2 values by stein's algorithm
        /// </summary>
        /// <param name="firstValue">first value for compute of GDC</param>
        /// <param name="secondValue">second value for compute of GDC</param>
        /// <returns></returns>
        private static int CalculateGDCBySteinsAlgorithm(int firstValue, int secondValue)
        {
            if (firstValue == 0) return secondValue;
            if (secondValue == 0) return firstValue;
            if (firstValue == secondValue) return firstValue;
            if (firstValue == 1 || secondValue == 1) return 1;
            if ((firstValue % 2 == 0) && (secondValue % 2 == 0)) return 2 * CalculateGDCBySteinsAlgorithm(firstValue / 2, secondValue / 2);
            if ((firstValue % 2 == 0) && (secondValue % 2 != 0)) return CalculateGDCBySteinsAlgorithm(firstValue / 2, secondValue);
            if ((firstValue % 2 != 0) && (secondValue % 2 == 0)) return CalculateGDCBySteinsAlgorithm(firstValue, secondValue / 2);
            return CalculateGDCBySteinsAlgorithm(secondValue, Math.Abs(firstValue - secondValue));            
        }

        private static int CalculateGDCBySteinsAlgorithm(int firstValue, int secondValue,int thirdvalue)
        {
            return CalculateGDCBySteinsAlgorithm(thirdvalue, CalculateGDCBySteinsAlgorithm(firstValue, secondValue));
        }

        /// <summary>
        /// Method return runtime of delegate with 2 parameters
        /// </summary>
        /// <param name="firstValue">first parameter</param>
        /// <param name="secondValue">second parameter</param>
        /// <param name="method">delegate for that compute runtime</param>
        /// <param name="runTime">runtime of delegate</param>
        /// <returns></returns>
        private static int ComputerTime(int firstValue, int secondValue, Func<int, int, int> method, out double runTime)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = method(firstValue, secondValue);
            stopWatch.Stop();
            runTime = stopWatch.Elapsed.TotalMilliseconds;
            return result;
        }


        /// <summary>
        /// Method return runtime of delegate with 3 parameters
        /// </summary>
        /// <param name="firstValue">first parameter</param>
        /// <param name="secondValue">second parameter</param>
        /// <param name="thirdValue">third parameter</param>
        /// <param name="method">delegate for that compute runtime</param>
        /// <param name="runTime">runtime of delegate</param>
        /// <returns></returns>
        private static int ComputerTime(int firstValue, int secondValue, int thirdValue, Func<int, int, int,int> method, out double runTime)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = method(firstValue, secondValue, thirdValue);
            stopWatch.Stop();
            runTime = stopWatch.Elapsed.TotalMilliseconds;
            return result;
        }
        #endregion
    }
}

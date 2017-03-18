using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class CalculateRoot
    {
        #region Public Methods
        /// <summary>
        /// Method that return square root of val
        /// </summary>
        /// <param name="val">value the square root that  need calculate</param>
        /// <param name="degree">the pow of val</param>
        /// <returns></returns>
        public static double GetRootByNewtonMethod(double val,int degree)
        {
            return  Sqrt(val,degree);
        }

        /// <summary>
        /// Comparers initial value before compute square root with restored value
        /// </summary>
        /// <param name="value">initial value</param>
        /// <param name="restoredValue">restored value</param>
        /// <returns></returns>
        public static bool ValidateRootNewtonMethod(int value, double restoredValue)
        {
            return Math.Abs(restoredValue - value) < 0.000001;
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Method that calculate square root of value
        /// </summary>
        /// <param name="val">value the square root that  need calculate</param>
        /// <param name="degree">the power of val</param>
        /// <returns></returns>
        private static double Sqrt(double val, int degree)
        {
            double x = 1;
            const double accuracy = 1e-15;
            while (true)
            {
                var nx = ((degree-1)*x + val / (Math.Pow(x,degree-1))) / degree;
                if (Math.Abs(x - nx) < accuracy) break;
                x = nx;
            }
            return (x);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{

    /// <summary>
    /// Provides functionality for view integer value to hex
    /// </summary>
    public static class IntegerExtension
    {
        #region Public Methods
        /// <summary>
        /// show int value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this int val)
        {
            return val.ToString("X");
        }

        /// <summary>
        /// show sbyte value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this sbyte val)
        {
            return val.ToString("X");
        }

        /// <summary>
        /// show byte value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this byte val)
        {
            return val.ToString("X");
        }

        /// <summary>
        /// show char value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this char val)
        {
            return ((int)val).ToString("X");
        }

        /// <summary>
        /// show short value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this short val)
        {
            return val.ToString("X");
        }

        /// <summary>
        /// show unshort value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this ushort val)
        {
            return val.ToString("X");
        }

        /// <summary>
        /// show uint value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this uint val)
        {
            return val.ToString("X");
        }

        /// <summary>
        /// show ulong value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this ulong val)
        {
            return val.ToString("X");
        }

        /// <summary>
        /// show long value to hex 
        /// </summary>
        /// <param name="val">transmitted value</param>
        /// <returns></returns>
        public static string ViewToHex(this long val)
        {
            return val.ToString("X");
        }
        #endregion
    }

}

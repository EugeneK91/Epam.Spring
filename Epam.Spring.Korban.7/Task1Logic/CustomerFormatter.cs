using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        #region Public Methods
        /// <summary>
        /// implementation getformat for ICustomFormatter
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            var t = formatType;
            if (formatType == typeof(ICustomFormatter)) return this;
            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }


        /// <summary>
        /// implementation format for IFormatProvider
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string value;
            var formattable = arg as IFormattable;
            if (formattable == null)
            {
                value = arg.ToString();
            }
            else
            {
                value = formattable.ToString(format, formatProvider);
            }
            return string.Format("{0}", value);
        }
        #endregion
    }
}

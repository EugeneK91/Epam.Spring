using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class Customer:IFormattable
    {

        #region Properties

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Telephone
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// Revenue
        /// </summary>
        public decimal Revenue { get; set; }
        #endregion

        #region Constructors

        public Customer() { }

        #endregion

        #region Public Methods
        /// <summary>
        /// implementation tostring for IFormattable, G-generalformat, N - Name,R - Revenue, T - Telephone
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (format == null) format = "G";

            if (formatProvider != null)
            {
                var formatter = formatProvider.GetFormat(this.GetType()) as ICustomFormatter;
                if (formatter != null)
                {
                    return formatter.Format(format, this, formatProvider);
                }
            }

            if (format == "G")
            {
                return string.Format("({0}, {1}, {2})", Name, Telephone, Revenue);
            }

            var sb = new StringBuilder("Customer record: ");
            int sourceIndex = 0;
            while (sourceIndex < format.Length)
            {
                switch (format[sourceIndex])
                {
                    case 'N':
                        sb.Append(Name);
                        break;
                    case 'T':
                        sb.Append(Telephone);
                        break;
                    case 'R':
                        sb.Append(Revenue.ToString());
                        break;
                    default:
                        sb.Append(format[sourceIndex]);
                        break;
                }
                sourceIndex++;
            }
            return sb.ToString(); 
        }
        #endregion
    }
}

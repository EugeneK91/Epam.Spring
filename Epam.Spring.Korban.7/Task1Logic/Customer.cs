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
        public string Name { get; set; }
        public string Telephone { get; set; }
        public decimal Revenue { get; set; }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            //"G" is .Net's standard for general formatting--all
            //types should support it
            if (format == null) format = "G";

            // is the user providing their own format provider?
            if (formatProvider != null)
            {
                var formatter = formatProvider.GetFormat(this.GetType()) as ICustomFormatter;
                if (formatter != null)
                {
                    return formatter.Format(format, this, formatProvider);
                }
            }

            //formatting is up to us, so let's do it
            if (format == "G")
            {
                return string.Format("({0}, {1}, {2})", Name, Telephone, Revenue);
            }

            StringBuilder sb = new StringBuilder();
            int sourceIndex = 0;
            while (sourceIndex < format.Length)
            {
                switch (format[sourceIndex])
                {
                    case 'N':
                        sb.Append(Name.ToString());
                        break;
                    case 'T':
                        sb.Append(Telephone.ToString());
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
    }

    public class TypeFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string value;
            IFormattable formattable = arg as IFormattable;
            if (formattable == null)
            {
                value = arg.ToString();
            }
            else
            {
                value = formattable.ToString(format, formatProvider);
            }
            return string.Format("Customer record: {0}", value);
        }
    }


}

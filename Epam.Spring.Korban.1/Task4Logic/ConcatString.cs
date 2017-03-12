using System;
using System.Linq;


namespace Task4Logic
{
    public class ConcatString
    {
        public static string GetConcatString(string str1,string str2)
        {
            if (str1 == null)
            {
                throw new ArgumentException("empty str1");
            }

            if (str2 == null)
            {
                throw new ArgumentException("empty str2");
            }

            return new string((str1 + str2).ToArray().Distinct().OrderBy(c => c).ToArray());
        }
    }
}

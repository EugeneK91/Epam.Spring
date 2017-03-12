using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4Logic;

namespace Task4Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var string1 = "qwertyuiopsdfghjklzxcvbnm";
            var string2 = "mnbvcxlkjhgfdpoiuytre";
            Console.WriteLine("Result string: " + ConcatString.GetConcatString(string1,string2));
        }
    }
}

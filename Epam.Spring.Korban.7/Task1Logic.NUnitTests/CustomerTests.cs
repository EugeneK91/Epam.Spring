using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic.NUnitTests
{
    public class CustomerTests
    {

        [TestCase("{0:N R T}", Result = "Customer record: Gogol 100000000 +1(425) 55-0100")]
        [TestCase("{0:R T N}", Result = "Customer record: 100000000 +1(425) 55-0100 Gogol")]
        [TestCase("{0:N T}", Result = "Customer record: Gogol +1(425) 55-0100")]
        [TestCase("{0:N}", Result = "Customer record: Gogol")]
        [TestCase("{0:T}", Result = "Customer record: +1(425) 55-0100")]
        public string Format_Test(string str)
        {
            var customerFormatter = new CustomerFormatter();
            var customer = new Customer { Name = "Gogol", Revenue = 100000000, Telephone = "+1(425) 55-0100" };
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(customerFormatter, str, customer);
            var result = customer.ToString(str, customerFormatter);
  
            return sb.ToString();
        }

        [TestCase("N R T", Result = "Customer record: Gogol 100000000 +1(425) 55-0100")]
        [TestCase("R T N", Result = "Customer record: 100000000 +1(425) 55-0100 Gogol")]
        [TestCase("(N T)", Result = "Customer record: (Gogol +1(425) 55-0100)")]
        [TestCase("N", Result = "Customer record: Gogol")]
        [TestCase("[T]", Result = "Customer record: [+1(425) 55-0100]")]
        public string ToString_Test(string str)
        {
            var customerFormatter = new CustomerFormatter();
            var customer = new Customer { Name = "Gogol", Revenue = 100000000, Telephone = "+1(425) 55-0100" };

            var result = customer.ToString(str, customerFormatter);

            return result;
        }

    }
}

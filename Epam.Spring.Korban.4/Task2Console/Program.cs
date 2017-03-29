using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new GenericQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            var t = queue.ToArray();

            foreach (var i in queue)
            {
                Console.Write(i+" ");
            }
        }
    }
}

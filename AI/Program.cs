using Apache.Ignite.Core;
using Apache.Ignite.Core.Binary;
using Apache.Ignite.Core.Compute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new IgniteConfiguration { BinaryConfiguration = new BinaryConfiguration(typeof(CountFunc)) };

            using(var ignite = Ignition.Start(cfg))
            {
                Console.Read();
            }            
        }
    }

    internal class CountFunc : IComputeFunc<int[], int>
    {
        public int Invoke(int[] arg)
        {
            int pr = 1;
            string arr = "";

            for (int i = 0; i < arg.Length; i++)
            {
                pr *= arg[i];
                arr += arg[i] + " ";
            }
            Console.WriteLine(arr + " Pr: " + pr);

            return pr;
        }
    }
}

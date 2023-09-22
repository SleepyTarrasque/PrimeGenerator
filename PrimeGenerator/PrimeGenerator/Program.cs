using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ulong> primes = new List<ulong>(); 

            //Fermat's Little Theorem Algorithm
            // 2^(n-1) == 1(mod n)

            
            
            ulong testnum = 2;

            while (testnum < 1500)
            {
                Console.WriteLine($"\nTesting {testnum}:\nThe result is 2^{testnum-1} = {(Math.Pow(2, testnum-1) % testnum)}(mod{testnum})");
               
                
                if ((Math.Pow(2, testnum - 1) % testnum) == 1)
                {
                    primes.Add(testnum);
                    Console.WriteLine($"Suspected prime:    {testnum}");
                }
                
                testnum++;
                
            }
            Console.ReadLine();
        }
    }
}

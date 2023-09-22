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
            List<ulong> susprimes = new List<ulong>(); 

            //Fermat's Little Theorem Algorithm
            // 2^(n-1) == 1(mod n)

            
            
            ulong testnum = 2;

            // Generate a list of possible primes
            while (testnum <= 1024)
            {
                Console.WriteLine($"\nTesting {testnum}:\nThe result is 2^{testnum-1} = {(Math.Pow(2, testnum-1) % testnum)}(mod{testnum})");
               
                
                if ((Math.Pow(2, testnum - 1) % testnum) == 1)
                {
                    susprimes.Add(testnum);
                    Console.WriteLine($"Suspected prime:    {testnum}");
                }
                else if (testnum == 2)
                {
                    susprimes.Add(testnum);
                    Console.WriteLine($"Suspected prime:    {testnum}");
                }
                
                testnum++;
                
            }


            Console.WriteLine("\n\nPSUEDOPRIME CHECKING:");
            

            // Run list of suspected primes through sieve
            for (int n = 0; n < susprimes.Count; n++)
            {
                testnum = susprimes[n];
                for (int i = 0; susprimes[i] < Math.Sqrt(susprimes[n]); i++)
                {
                    ulong divisortest = susprimes[i];

                    if (testnum % divisortest == 0)
                    {
                        Console.WriteLine($"{testnum} is a psuedoprime divisible by {divisortest}.\n");
                        susprimes.RemoveAt(n);
                        n--;
                        break;
                    }
                }
            }

            // Output list of primes
            Console.WriteLine("\n\nFINAL PRIME LIST:");
            for (int i = 0; i < susprimes.Count; i++)
            {
                int m = (i + 1) % 10;
                switch (m) 
                {
                    case 1: { Console.WriteLine((i + 1) + "st prime is:   " + susprimes[i]); break; }

                    case 2: { Console.WriteLine((i + 1) + "nd prime is:   " + susprimes[i]); break; }

                    case 3: {
                            if ((i + 1) % 100 == 13){ Console.WriteLine((i + 1) + "th prime is:   " + susprimes[i]); break; }
                            else { Console.WriteLine((i + 1) + "rd prime is:   " + susprimes[i]); break; }
                            }
                    
                    default: { Console.WriteLine((i + 1) + "th prime is:   " + susprimes[i]); break; }
                }
            }
            Console.ReadLine();

        }
    }
}

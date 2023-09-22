using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PrimeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger testnum = new BigInteger();
            BigInteger divisortest = new BigInteger();
            List<BigInteger> susprimes = new List<BigInteger>(); 

            // Fermat's Little Theorem Algorithm
            //   2^(n-1) == 1(mod n),  for n > 2

            
            testnum = 3; // starts searching for primes at 3
            susprimes.Add(2); // manually adds 2 as the first prime, as it fails FLT
            Console.WriteLine("Input the maximum number you would like to test:");
            int maxval = int.Parse(Console.ReadLine());



            ////  POSSIBLE PRIME GENERATION  ////
            while (testnum <= maxval)
            {
                Console.WriteLine($"\nTesting {testnum}:\nThe result is 2^{testnum-1} = {(BigInteger.ModPow(2, testnum - 1, testnum))}(mod{testnum})");
               
                
                if ((BigInteger.ModPow(2,testnum-1,testnum)) == 1)
                {
                    susprimes.Add(testnum);
                    Console.WriteLine($"Suspected prime:    {testnum}");
                }
                
                testnum++;
                
            }



            ////  PSUEDOPRIME CHECKING  ////
            Console.WriteLine("\n\nPSUEDOPRIME CHECKING:");
            // Run list of suspected primes through Sieve of Eratosthenes to eliminate psuedoprimes
            for (int n = 0; n < susprimes.Count; n++)
            {
                testnum = susprimes[n];
                for (int i = 0; (double)susprimes[i] < Math.Exp(BigInteger.Log((susprimes[n]) / 2)); i++)
                {
                    divisortest = susprimes[i];

                    if (testnum % divisortest == 0)
                    {
                        Console.WriteLine($"{testnum} is a psuedoprime divisible by {divisortest}.\n");
                        susprimes.RemoveAt(n);
                        n--; // Because susprimes[n] is now a new value, it needs to be retested
                        break;
                    }
                }
            }

            ////  OUTPUT LIST OF PRIMES  ////
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

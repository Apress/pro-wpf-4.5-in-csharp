#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Multithreading
{
    public class Worker
    {
        public static int[] FindPrimes(int fromNumber, int toNumber)
        {
            return FindPrimes(fromNumber, toNumber, null);
        }

        public static int[] FindPrimes(int fromNumber, int toNumber, System.ComponentModel.BackgroundWorker backgroundWorker)
        {
            int[] list = new int[toNumber - fromNumber];

            // Create an array containing all integers between the two specified numbers.
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = fromNumber;
                fromNumber += 1;
            }


            //find out the module for each item in list, divided by each d, where
            //d is < or == to sqrt(to)
            //if the remainder is 0, the nubmer is a composite, and thus
            //we mark its position with 0 in the marks array,
            //otherwise the number is a prime, and thus mark it with 1
            int maxDiv = (int)Math.Floor(Math.Sqrt(toNumber));

            int[] mark = new int[list.Length];


            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 2; j <= maxDiv; j++)
                {

                    if ((list[i] != j) && (list[i] % j == 0))
                    {
                        mark[i] = 1;
                    }

                }

                
				int iteration = list.Length / 100;
                if ((i % iteration == 0) && (backgroundWorker != null))
                {                
                    if (backgroundWorker.CancellationPending)
                    {
                        // Return without doing any more work.
                        return null;                      
                    }

                    if (backgroundWorker.WorkerReportsProgress)
                    {
                        //float progress = ((float)(i + 1)) / list.Length * 100;
                        backgroundWorker.ReportProgress(i / iteration);
                        //(int)Math.Round(progress));
                    }
                }

            }

            //create new array that contains only the primes, and return that array
            int primes = 0;
            for (int i = 0; i < mark.Length; i++)
            {
                if (mark[i] == 0) primes += 1;

            }

            int[] ret = new int[primes];
            int curs = 0;
            for (int i = 0; i < mark.Length; i++)
            {
                if (mark[i] == 0)
                {
                    ret[curs] = list[i];
                    curs += 1;
                }
            }

            if (backgroundWorker != null && backgroundWorker.WorkerReportsProgress)
            {
                backgroundWorker.ReportProgress(100);
            }

            return ret;

        }

        
    }
}

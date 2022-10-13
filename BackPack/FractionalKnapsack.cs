using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPack
{
    public class FractionalKnapsack
    {
        //public FractionalKnapsack()
        //{
        //}

        public static void KnapsackGreProc(int[] W, int[] V, int M, int n)
        {
            //Initialize weight and value for each knapsack package:
            KnapsackPackage[] packs = new KnapsackPackage[n];
            for (int k = 0; k < n; k++)
                packs[k] = new KnapsackPackage(W[k], V[k]);

            //Sort knapsack packages by cost with descending order using lambda expression:
            Array.Sort<KnapsackPackage>(packs, new Comparison<KnapsackPackage>(
                (kPackA, kPackB) => kPackB.Cost.CompareTo(kPackA.Cost)));

            double remain = M;
            double result = 0d;

            int i = 0;
            bool stopProc = false;

            while (!stopProc)
            {
                //If select package i:
                if (packs[i].Weight <= remain)
                {
                    remain -= packs[i].Weight;
                    result += packs[i].Value;

                    Console.WriteLine("Pack " + i + " - Weight " + packs[i].Weight + " - Value " + packs[i].Value);
                }

                //If select the number of package i is enough:
                if (packs[i].Weight > remain)
                {
                    i++;
                }

                //Stop when browsing all packages
                if (i == n)
                {
                    stopProc = true;
                }
            }

            Console.WriteLine("Max Value:\t" + result);
        }
    }
}

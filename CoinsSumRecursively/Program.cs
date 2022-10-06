using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsSumRecursively
{
    class Program
    {
        public static int MinCoinsSum(int totalSum, List<int> coins)
        {
            //if the list is empty, we finished
            if (coins.Count == 0)
                return 0;

            //example: sum = 55, we have coins with nominal 5, 10, 20
            // 1. total = 55
            // 2. list is 20, 10, 5
            // 3. we get 20 and we remove 20m from the list, so the list remains 10, 5
            // 4. we return 55/20 + MinCoinsSum(55%20, coins) => recursion (15, {10,5})
            // 5. then we return 15/10 + MinCoinsSum(15%10, coins) => recursion (5, {5})
            // 6. then we return 5/5 + MinCoinsSum(5%5, coins) => recursion (5, {}) -> this is the bottom of the recursion - empty list
            // 7. we go back: 1 + 1 + 2 = 4 coins

            int total = totalSum;
            coins.Sort();
            coins.Reverse();
            int nominal = coins[0];
            coins.RemoveAt(0);
            return total / nominal + MinCoinsSum(total % nominal, coins);
        }
        static void Main(string[] args)
        {
            int totalSum = 60;
            List<int> coins = new List<int> { 5, 10, 20 };

            Console.WriteLine("Our nominals are {0}. We need minimum {1} coins for sum = {2}.",string.Join(", ", coins), MinCoinsSum(totalSum, coins), totalSum);

            Console.ReadKey();
        }
    }
}

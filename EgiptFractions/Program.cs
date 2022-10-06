using System;

namespace EgiptFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Дроб: 7/9
            int p = 7, q = 9;

            EgyptionFractionIteratively(p, q);
            Console.WriteLine();
            EgyptionFractionRecursively(p, q);
            Console.WriteLine();

            int x = 19;
            int y = 3;
            int courses = (int)Math.Ceiling((double)x / y);
            Console.WriteLine(courses);


            Console.ReadKey();
        }

        static void EgyptionFractionIteratively(int p, int q)
        {
            int r = 0;
            while (p > 1)
            {
                r = (p + q) / p; // r=(7+9)/7=2
                Console.Write("1/{0} + ", r);

                // Общ знаменател
                p = p * r - q; // p = 7*2-9 = 5
                q = q * r; // q = 9*2 = 18

                // Съкращение с НОД
                int m = gcd(p, q);
                p = p / m;
                q = q / m;
            }
            Console.Write("1/{0}", q);
        }

        // Greatest common divisor
        private static int gcd(int a, int b)
        {
            if (a > b)
                return gcd(a - b, b);
            else if (b > a)
                return gcd(a, b - a);
            return a;
        }

        static void EgyptionFractionRecursively(int p, int q)
        {
            // If either numerator or  denominator is 0 - base case (bottom of the recurssion) -> 0/1; 1/0; 0/0
            if (p == 0 || q == 0)
                return;

            // If numerator divides denominator, then simple division  makes the fraction in 1/n form
            // For example 2/6, 3/9, 4/16...
            if (q % p == 0)
            {
                Console.Write("1/" + q / p);
                return;
            }

            // If denominator divides numerator, then the given number is not fraction
            // For example 6/3, 12/4, ...
            if (p % q == 0)
            {
                Console.Write(p / q);
                return;
            }

            // If numerator is more than denominator
            // For example 7/3 = 2 + 1/3 -> Here we need recursively call the method for 1/3
            if (p > q)
            {
                Console.Write(p / q + " + ");
                // !!! Recursion:
                EgyptionFractionRecursively(p % q, q);
                return;
            }

            // We reach here dr > nr and q % p != 0. 
            // For example 2/7 -> 7 > 2 and 7 % 2 != 0:
            // We need to find ceiling of dr/nr (it's dr/nr+1) and print it as first fraction -> 
            // For example 2/7 -> n = 7/2 + 1 = 4
            int n = q / p + 1;
            Console.Write("1/" + n + " + ");

            // Then we need to find the remaining part of the fraction (nr*n-dr) and recur for this remaining part ->
            // For example 2/7 ->
            // recursiveli call EgyptionFractionRecursively(1, 28) -> remainig part is 1/28
            EgyptionFractionRecursively(p * n - q, q * n);
        }

        /*
         Example -> 6/14:
         Main calls EgyptionFractionRecursively(6,14) -> prints 1/(14/6+1) = 1/3 and calls 
         EgyptionFractionRecursively(4,42)) -> prints 1/(42/4+1) = 1/(10+1) = 1/11 and calls 
         EgyptionFractionRecursively(1, 231) -> prints 1/231
         */
    }
}

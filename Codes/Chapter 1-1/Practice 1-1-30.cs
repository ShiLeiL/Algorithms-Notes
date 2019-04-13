using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.30 */
        public static int gcd(int p, int q)
        {
            //欧几里德算法，求最大公约数
            if (q == 0) return p;
            int r = p % q;
            return gcd(q, r);
        }

        public static void Main(String[] args)
        {
            int N = 10;
            bool[,] a = new bool[N, N];
            for(int i=0;i<N;i++)
            {
                for(int j=0;j<N;j++)
                {
                    if (gcd(i, j) == 1) a[i, j] = true;
                    else a[i, j] = false;
                    Console.Write($"{a[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
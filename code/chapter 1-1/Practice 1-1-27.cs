using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.27 */
        //因为该函数会递归多次，所以不建议运行
        public static int depth = 0;
        public static double binomial(int N, int k, double p)
        {
            ++depth;
            if (N == 0 && k == 0) return 1.0;
            if (N < 0 || k < 0) return 0.0;
            return (1.0 - p) * binomial(N - 1, k, p) + p * binomial(N - 1, k - 1, p);
        }

        public static void Main(String[] args)
        {
            //打印递归深度
            int N = 50;
            int k = 25;
            double p = 0.25;
            binomial(N, k, p);
            Console.WriteLine($"The program's depth is {depth}");
            Console.ReadKey();
        }
    }
}
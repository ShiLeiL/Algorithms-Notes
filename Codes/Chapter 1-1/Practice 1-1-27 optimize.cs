using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.27 optimize*/
        public static int N = 100;
        public static int k = 50;
        public static int depth = 0;
        public static double?[,] record = new double?[N + 1, k + 1];
        public static double? binomial(int N, int k, double p)
        {
            ++depth;
            if (N == 0 && k == 0) return 1.0;
            if (N < 0 || k < 0) return 0.0;
            if (record[N, k] != null) return record[N, k];
            record[N, k] = (1.0 - p) * binomial(N - 1, k, p) + p * binomial(N - 1, k - 1, p);
            return record[N, k];
        }

        public static void Main(String[] args)
        {
            //打印计算结果和递归深度
            double p = 0.25;
            Console.WriteLine($"The program's result is {binomial(N, k, p)}");
            Console.WriteLine($"The program's depth is {depth}");
            Console.ReadKey();
        }
    }
}
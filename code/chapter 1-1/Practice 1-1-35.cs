using System;
using System.Linq;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.35 */       
        static void Main(string[] args)
        {
            int SIDES = 6;
            double[] dist = new double[2 * SIDES + 1];
            Probability(dist, SIDES);

            Console.WriteLine("请输入实验个数:");
            int N = Convert.ToInt32(Console.ReadLine());
            double[] result = Simulation(N);

            if (Enumerable.SequenceEqual(dist, result))
                Console.WriteLine("与准确数据一致");
            else Console.WriteLine("与准确数据不一致");

            Console.WriteLine();
            Console.WriteLine("\t经验数据\t准确数据");
            for (int i = 0; i < result.Length; i++)
                Console.WriteLine($"{i}\t{result[i]}\t\t{dist[i]}");
            Console.ReadKey();
        }

        static void Probability(double[] dist,int SIDES)
        {
            //计算的两数之和的概率
            for(int i=1;i<=SIDES;i++)
            {
                for (int j = 1; j <= SIDES; j++) dist[i + j] += 1.0;
            }

            for (int k = 2; k <= 2 * SIDES; k++) dist[k] = Math.Round(dist[k]/36.0,3);
        }

        static double[] Simulation(int N)
        {
            //模拟掷骰子
            Random k = new Random();
            int[,] counts = new int[7, 7];
            double[] dist = new double[13];
            for(int i=0;i<N;i++)
            {
                int a = k.Next(1, 7);
                int b = k.Next(1, 7);
                counts[a,b]++;
                dist[a+b]++;
            }

            for (int j = 0; j <dist.Length; j++)
                dist[j] = Math.Round(dist[j] / N, 3);
            return dist;
        }
    }
}
using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.36 */
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组大小M：");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入打乱次数N：");
            int N = Convert.ToInt32(Console.ReadLine());

            ShuffleTest(M, N);
            Console.ReadKey();
        }

        static void shuffle(int[] a)
        {
            //题目源码改编
            int N = a.Length;
            Random k = new Random(Guid.NewGuid().GetHashCode());//改成哈希种子，以免自动计算时得到的结果一致
            for(int i=0;i<N;i++)
            {
                //将a[i]和a[i..N-1]中任意一个元素交换
                int r = i + (int)(k.NextDouble()*(N-i));
                int temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        static void ShuffleTest(int M, int N)
        {
            int[] test = new int[M];
            for (int i = 0; i < M; i++)
                test[i] = i;
            int[,] counts = new int[M, M];
            for(int i=0;i<N;i++)
            {
                shuffle(test);
                for(int j=0;j<M;j++)
                {
                    counts[test[j],j]++;
                    test[j] = j;
                }
            }

            //输出
            Console.WriteLine();
            foreach (int i in test)
                Console.Write($"\t{i}");
            Console.WriteLine();
            for (int i=0;i<M;i++)
            {
                Console.Write($"{i}\t");
                for (int j=0;j<M;j++)
                {
                    Console.Write($"{counts[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
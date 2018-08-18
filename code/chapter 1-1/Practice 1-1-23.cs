using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.23 */
        public static int rank(int key, int[] a)
        { return rank(key, a, 0, a.Length - 1); }

        public static int rank(int key, int[] a, int lo, int hi)
        {
            //如果key存在于a[]中，它的索引不会小于lo且不会大于hi
            if (lo > hi) return -1;
            int mid = lo + (hi - lo) / 2;
            if (key < a[mid]) return rank(key, a, lo, mid - 1);
            else if (key > a[mid]) return rank(key, a, mid + 1, hi);
            else return mid;
        }

        static void Main(string[] args)
        {
            //测试，创建一个测试数据
            int count = 50;
            int[] a = new int[count];
            for (int i = 0; i < count; i++)
            {
                a[i] = i;
            }

            //输入要查询的值和类型
            int[] key = new int[5];
            for(int i=0;i<5;i++)
            {
                Console.WriteLine("请输入要查找的数据：");
                key[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine("请输入要查找的类型（+或-）：");
            string ty = Console.ReadLine();

            //输出
            for (int i = 0; i < 5; i++)
            {
                if (ty == "+" && rank(key[i], a) != -1)
                {
                    Console.Write($"{key[i]} ");
                }
                else if (ty == "-" && rank(key[i], a) == -1)
                {
                    Console.Write($"{key[i]} ");
                }
            }
            Console.ReadKey();
        }
    }
}
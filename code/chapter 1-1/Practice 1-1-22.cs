using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.22 */
        public static int rank(int key, int[] a)
        { return rank(key, a, 0, a.Length - 1, 0); }

        public static int rank(int key, int[] a, int lo, int hi, int de)
        {
            //如果key存在于a[]中，它的索引不会小于lo且不会大于hi
            ++de;
            for (int i = 0; i < de; i++)
            {
                Console.Write("  ");
            }
            Console.WriteLine($"depth:{de}  lo:{lo}  hi:{hi}");
            if (lo > hi) return -1;
            int mid = lo + (hi - lo) / 2;
            if (key < a[mid]) return rank(key, a, lo, mid - 1, de);
            else if (key > a[mid]) return rank(key, a, mid + 1, hi, de);
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
            int key = 26;
            int result = rank(key, a);
            Console.WriteLine();
            Console.WriteLine($"key's position is:{result}");
            Console.ReadKey();
        }
    }
}
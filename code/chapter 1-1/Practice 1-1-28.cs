using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.28 */
        /*个人理解题意为：更改书中15页上的BinarySearch的rank()方法的实现
          使其用于删除排序之后的数列中的重复元素*/
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
            int[] a = {1,1,3,5,5,7,9,9,11,20,20 };
            for (int i = 0; i < a.Length; i++)
            {
                if (rank(a[i], a,i+1,a.Length-1) == -1)
                    Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        /* 算法（第四版） 1.1.29 */
        /*有更简便的方法，但个人理解题意是需要与原rank方法有联系，故作答如下*/
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

        public static int rank1(int key, int[] a)
        {
            //返回数组中小于该键的元素数量
            int position=rank(key, a);
            if (position == -1) return 0;
            for(int i=position-1;i>0;i--)
            {
                if(a[i]<a[position]) break;
                --position;
            }
            for (int i = 0; i < position; i++)
                Console.Write($"{a[i]} ");
            Console.WriteLine();
            return position;
        }

        public static int count(int key,int[] a)
        {
            //返回等于key的元素数量
            int position = rank(key, a);
            if (position == -1) return 0;
            for (int i = position - 1; i > 0; i--)
            {
                if (a[i] < a[position]) break;
                --position;
            }
            int counts = 1;
            for(int i=position+1;i<a.Length;i++)
            {
                if (a[i] > a[position]) break;
                ++counts;
            }
            return counts;
        }

        static void Main(string[] args)
        {
            //测试，创建一个测试数据
            int[] a = { 1, 1, 3, 5, 5,5,5,5, 7, 9, 9,9,9, 11, 20, 20 };
            int key = 9;
            int result1 = rank(key, a);
            int result2 = rank1(key, a);
            int result3 = count(key, a);
            Console.WriteLine($"key's position is:{result1}");
            Console.WriteLine($"the count of less than key is:{result2}");
            Console.WriteLine($"the count of be equal to key is:{result3}");
            Console.ReadKey();
        }
    }
}
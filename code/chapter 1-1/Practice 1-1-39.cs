using System;
namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.1.39 */
            //实验次数建议不要输太大
            //本机输入10次，程序运行时间约为6.5S左右
            Console.WriteLine("请输入实验运行次数T：");
            int T = Convert.ToInt32(Console.ReadLine());

            int[] sum = new int[4];
            for (int i = 0; i < T; i++)
            {
                sum[0] += Test(1000);
                sum[1] += Test(10000);
                sum[2] += Test(100000);
                sum[3] += Test(1000000);
            }
            Console.WriteLine();

            Console.WriteLine("不同的N重复的整数数量的平均值为：");
            double result = 0;
            foreach (int k in sum)
            {
                result = k*1.000 / 10;
                Console.WriteLine(Math.Round(result));
            }               
            Console.ReadKey();
        }

        static int Test(int N)
        {
            Random k = new Random(Guid.NewGuid().GetHashCode());
            int[] a = new int[N];
            int[] b = new int[N];
            a[0] = 100000;
            b[0] = a[0];
            for (int i = 1; i < N; i++)
            {
                a[i] = k.Next(100000,1000000);
                b[i] = k.Next(100000, 1000000);
            }

            Array.Sort(b);//对b进行排序
            int counts = 0;
            for (int i = 0; i < N; i++)
            {
                if (BinarySearch(a[i], b)) counts++;
            }
            return counts;
        }

        static bool BinarySearch(int key, int[] a)
        {
            //数组必须是有序的
            int lo = 0;
            int hi = a.Length - 1;
            while (lo <= hi)
            {
                //被查找的键要么不存在，要么必然存在于a[lo...hi]之中
                int mid = lo + (hi - lo) / 2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else return true;
            }
            return false;
        }

        static void pai(int[] a)
        {

        }
    }
}
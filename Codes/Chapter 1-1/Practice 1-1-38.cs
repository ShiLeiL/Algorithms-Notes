using System;
using System.Diagnostics;
using System.IO;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.1.36 */
            //不建议运行读取书上数据运行暴力查找
            //本机运行书上数据，暴力查找运行很久运行不完
            //而二分查找（包括排序时间）只要1300毫秒左右
            //由此可见运行时间差距

            //处理文件数据
            string[] strsT = File.ReadAllLines(@"数据地址");
            string[] strsW = File.ReadAllLines(@"数据地址");
            int[] intT = new int[strsT.Length];
            int[] intTC = new int[strsT.Length];
            int[] intW = new int[strsW.Length];
            for (int i = 0; i < strsT.Length; i++)
            {
                intT[i] = Convert.ToInt32(strsT[i]);
                intTC[i] = Convert.ToInt32(strsT[i]);
            }                
            for (int i = 0; i < strsW.Length; i++)
                intW[i] = Convert.ToInt32(strsW[i]);

            Stopwatch stw = new Stopwatch();//计时器

            //计时二分查找
            stw.Restart();
            Array.Sort(intTC);//对目标数组进行排序，这里把排序时间算在里面了
            for (int i = 0; i < intW.Length; i++)
                BinarySearch(intW[i], intT);
            stw.Stop();
            TimeSpan tis = stw.Elapsed;
            Console.WriteLine($"the Binary Search takes {tis.TotalMilliseconds} ms.");

            //计时暴力查找
            stw.Start();
            for (int i = 0; i < intW.Length; i++)
                BruteForceSearch(intW[i], intT);
            stw.Stop();
            tis = stw.Elapsed;//时间间隔
            Console.WriteLine($"the Brute Force Search takes {tis.TotalMilliseconds} ms.");
            
        }
        
        static int BruteForceSearch(int key,int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] == key) return i;
            return -1;
        }

        static int BinarySearch(int key,int[] a)
        {
            //数组必须是有序的
            int lo = 0;
            int hi = a.Length - 1;
            while(lo<=hi)
            {
                //被查找的键要么不存在，要么必然存在于a[lo...hi]之中
                int mid = lo + (hi - lo) / 2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else return mid;
            }
            return -1;
        }
    }
}
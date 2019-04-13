using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.2.9 */
            //处理输入
            Console.WriteLine("请输入要查询的数字：");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入要查询的数组（以逗号隔开）：");
            string[] inP = Console.ReadLine().Split(',');
            int[] a = new int[inP.Length];
            for(int i=0;i<inP.Length;i++)
                a[i]=Convert.ToInt32(inP[i]);
        
            Counter count = new Counter("counts");
            Console.WriteLine();
            Console.WriteLine(rank(key, a, count));
            Console.WriteLine(count.toString());
            Console.ReadKey();
        }

        public static int rank(int key,int[] a,Counter count)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while(lo<=hi)
            {
                //被查找的键要么不存在，要么必然存在于a[lo..hi]之中
                count.increment();
                int mid = lo + (hi - lo) / 2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else return mid;
            }
            return -1;
        }
    }

    public class Counter
    {
        private readonly string name;
        private int count;
        
        public Counter(string id)
        { name = id; }

        public void increment()
        { count++; }

        public int tally()
        { return count; }

        public string toString()
        { return count + " " + name; }
    }
}
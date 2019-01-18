using System;
using System.IO;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.4.8 */
            string[] Nums = File.ReadAllLines("Nums.txt");
            int[] a = new int[Nums.Length];
            for (int i = 0; i < a.Length; i++)
                a[i] = Convert.ToInt32(Nums[i]);
            Console.WriteLine(count(a));
        }

        public static int count(int[] a)
        {
            Array.Sort(a);
            int N = a.Length;
            int cnt = 0;
            int temp = 0;
            for(int i=1;i<N;i++)
            {
                if (a[i] == a[i - 1])
                    temp++;
                else
                {
                    cnt += temp * (temp + 1) / 2;
                    temp = 0;
                }
            }
            return cnt;
        }
    }
}
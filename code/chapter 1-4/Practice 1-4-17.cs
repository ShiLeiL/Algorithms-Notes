using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        public static void Distant(double[] a)
        {
            /* 算法（第四版） 1.4.17 */
            int max = 0, min = 0;
            for(int i=1;i<a.Length;i++)
            {
                if (a[i] > a[max])
                    max = i;
                if (a[i] < a[min])
                    min = i;
            }
            Console.WriteLine($"最遥远的两个数为：{a[min]},{a[max]}");
        }
    }
}
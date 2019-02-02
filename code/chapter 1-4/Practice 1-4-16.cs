using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        public static void Approaching(double[] a)
        {
            /* 算法（第四版） 1.4.16 */
            Array.Sort(a);
            int a1 = 0;
            double min = 9999999999999;
            for (int i = 0; i < a.Length && min != 0; i++)
            {
                double difference = a[i + 1] - a[i];
                if (difference < min)
                {
                    min = difference;
                    a1 = i;
                }
            }
            Console.WriteLine($"最接近的两个数为：{a[a1]},{a[a1 + 1]}");
        }
    }
}
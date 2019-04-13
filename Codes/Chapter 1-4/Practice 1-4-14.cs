using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        public static int count(int[] a)
        {
            /* 算法（第四版） 1.4.14 */
            Array.Sort(a);
            int N = a.Length;
            int cnt = 0;
            for (int i = 0; i < N; i++)
                for (int j = i + 1; j < N; j++)
                    for (int k = j + 1; k < N; k++)
                        if (BinarySearch.rank(-a[i] - a[j] - a[k], a) > k)
                            cnt++;
            return cnt;
        }
    }
}
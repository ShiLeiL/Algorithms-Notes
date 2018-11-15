using System;
namespace AlgorithmsApplication
{
    public class ThreeSum
    {
        /* 算法（第四版） 1.4.2 */
        public static int count(int[] a)
        {
            //统计和为0的元组的数量
            int N = a.Length;
            int cnt = 0;
            for (int i = 0; i < N; i++)
                for (int j = i + 1; i < N; j++)
                    for (int k = j + 1; k < N; k++)
                        if ((long)a[i] + a[j] + a[k] == 0)
                            cnt++;
            return cnt;
        }
    }
}
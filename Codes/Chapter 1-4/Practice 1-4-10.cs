using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        public static int RankMin(int key, int[] a)
        {
            /* 算法（第四版） 1.4.10 */
            //思路为：若找到一个a[mid]等于key，用min记录mid
            //       再继续寻找lo到mid-1是否还有等于key的数
            int lo = 0;
            int hi = a.Length - 1;
            int min = -1; //记录最小数
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < a[mid])
                    hi = mid - 1;
                else if (key > a[mid])
                    lo = mid + 1;
                else 
                {
                    min = mid; 
                    hi = mid - 1;
                }
            }
            return min;
        }
    }
}
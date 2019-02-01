using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        public static int howMany(int key, int[] a)
        {
            /* 算法（第四版） 1.4.11 */
            //照着1.4.10多写了个rankMax
            //不直接用rank递归是因为在过程中会重复遍历全都是key值的区间
            //故分两个部分进行计算
            return rankMax(key, a) - rankMin(key, a) + 1;            
        }

        public static int rankMin(int key, int[] a)
        {
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
                    hi = mid-1;
                }
            }
            return min;
        }

        public static int rankMax(int key, int[] a)
        {
            int lo = 0;
            int hi = a.Length - 1;
            int max = -2; //记录最大数，因最后结果要+1，故为-2
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < a[mid])
                    hi = mid - 1;
                else if (key > a[mid])
                    lo = mid + 1;
                else
                {
                    max = mid;
                    lo = mid + 1;
                }
            }
            return max;
        }
    }
}
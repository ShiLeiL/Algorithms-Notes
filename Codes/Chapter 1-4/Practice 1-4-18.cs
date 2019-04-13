using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        public static int localMin(int[] a,int lo,int hi)
        {
            /* 算法（第四版） 1.4.18 */
            if (hi <= lo)
                return -1;

            //防止验证到边界时，对比时下标超出界限
            int mid = lo + (hi - lo) / 2;            
            if (mid == 0)
                mid++;
            else if (mid == a.Length)
                mid--;

            //先判断较小的一边
            //若较小的一边没有则判断较大的一边
            if (a[mid - 1] < a[mid])
            {
                int temp =  localMin(a, lo, mid - 1);
                if (temp == -1)
                    return localMin(a, mid + 1, hi);
                return temp;
            }
            else if (a[mid + 1] < a[mid])
            {
                int temp = localMin(a, mid+1, hi);
                if (temp == -1)
                    return localMin(a, lo, mid-1);
                return temp;
            }
            else
                return mid;
        }
    }
}
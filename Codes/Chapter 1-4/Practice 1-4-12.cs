using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        public static void conmonNum(int[] a,int[] b)
        {
            /* 算法（第四版） 1.4.12 */
            Queue temp = new Queue();//防止重复记录
            int i = 0, j = 0, k = 0;
            while(i<a.Length&&j<b.Length)
            {
                if (a[i] < b[j])
                    i++;
                else if (a[i] > b[j])
                    j++;
                else
                {
                    if (!temp.Contains(a[i]))
                        temp.Enqueue(a[i]);
                    i++;j++;
                }
            }
            foreach (int z in temp)
                Console.Write(z + " ");
        }
    }
}
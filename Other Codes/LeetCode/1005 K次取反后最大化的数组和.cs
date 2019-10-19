//这是第一次的提交记录
//执行用时116ms，超过100%的C#提交记录=v=
//思路是先对数组进行排序，并对K的次数进行递减判断
//以j来记录数组指针，当指向的元素<0时，取反并K-1
//当指向的元素=0时，说明负数都变成正数或没有负数，退出循环
//当指向的元素>0时，先判断K的值，若K的值为双数就退出循环
//若为单数，则对比元素和元素前一个取反的负数的值，谁小谁取反

public class Solution {
    public int LargestSumAfterKNegations(int[] A, int K)
    {
        if (A.Length == 0) return 0;
        Array.Sort(A);//排序
        int j = 0;//数组指针
        for (int i = K; i > 0; i--)//以i代替K来进行递减
        {
            if (A[j] == 0) break;//元素等于0直接退出循环
            else if (A[j] > 0)
            {
                if (i % 2 == 0) break;//元素大于0且剩余的i为双数就退出循环
                //若第一个值就为正或元素小于前一个取反的负数，则取该元素的反并退出循环
                else if (j == 0 || A[j] < A[j - 1])
                {
                    A[j] = -A[j];
                    break;
                }
                else if (A[j] >= A[j - 1])//若元素大于前一个取反的负数，则取该前一个元素的反并退出循环
                {
                    A[j - 1] = -A[j - 1];
                    break;
                }
            }
            else { A[j] = -A[j++]; }//元素小于0直接取反
        }
        int sum = 0;
        foreach (int k in A)//计算数组和
        { sum += k; }
        return sum;
    }
}
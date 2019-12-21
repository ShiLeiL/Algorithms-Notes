//题目：给定一个整数数组和一个整数 k，判断数组中是否存在两个不同的索引 i 和 j，
//使得 nums [i] = nums [j]，并且 i 和 j 的差的绝对值最大为 k。
//例：输入: nums = [1,2,3,1], k = 3
//   输出: true

//这是第一次的提交记录
//执行用时128ms，超过81.25%的C#提交记录=0=
//思路是纵向遍历字符串数组
//当出现，当前字符比前一个字符小，则直接退出该列对比，次数加1


public class Solution 
{
    public int MinDeletionSize(string[] A)
    {
        int count = 0;
        for(int i=0;i<A[0].Length;i++)
        {
            for(int j=1;j<A.Length;j++)
            {
                if(A[j][i]<A[j-1][i])
                {
                    count++;
                    break;
                }
            }
        }
        return count;
    }
}
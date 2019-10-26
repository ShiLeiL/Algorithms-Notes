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
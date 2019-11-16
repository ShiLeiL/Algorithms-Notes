//这是第一次的提交记录
//执行用时108ms，超过89.58%的C#提交记录=v=
//思路是先复制一个对比数组，并把这个数组进行排序
//用对比数组跟原数组做比较，当值不一样时，记录一次

public class Solution 
{
    public int HeightChecker(int[] heights)
    {
        int[] temp = (int[])heights.Clone();
        int count = 0;
        Array.Sort(temp);
        for (int i = 0; i < temp.Length; i++)
            if (temp[i] != heights[i])
                count++;
        return count;
    }
}
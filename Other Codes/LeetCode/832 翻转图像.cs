//这是第N次的提交记录
//执行用时288ms，超过93.85%的C#提交记录=v=
//思路是遍历数组，在翻转的同时反转当前元素
//ps.反转思路是用的大佬的，也可以跟1取异或


public class Solution 
{
    public int[][] FlipAndInvertImage(int[][] A)
    {
        int c = A[0].Length - 1;
        foreach (int[] i in A)
            for (int j = 0; j < (c + 2) / 2; j++)
            {
                int temp = 1 - i[j];
                i[j] = 1 - i[c - j];
                i[c - j] = temp;
            }
        return A;
    }
}
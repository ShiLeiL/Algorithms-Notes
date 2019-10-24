//这是官方的题解（个人的思路不值一提）
//因为觉得太巧妙了，所以以此为记录
//思路是任意数字n与n-1做与运算，就会把最后一个1变为0


public class Solution 
{
    public int HammingWeight(uint n) 
    {
        int sum = 0;
        while (n != 0) 
        {
            sum++;
            n &= (n - 1);
        }
    return sum;
    }
}
//这是第一次的提交记录
//执行用时108ms，超过89.47%的C#提交记录=v=（明明跟能看到的最快用例是一样的代码。。）
//看了一下最快用例的代码，觉得非常精妙，所以提交了一下做个记录
//没有用备忘录记录所有值，而是采用了一个值记录上一次得到的值
//（因为公式本身只用对比计算f(k-2)和f(k-1)，所以这个代码省了很多内存

public class Solution 
{
    public int Rob(int[] nums) 
    {
        int cur = 0;
        int pre = 0;
        for(int i=0;i<nums.Length;i++)
        {
            int tmp = cur;
            cur = Math.Max(nums[i] + pre, cur);
            pre = tmp;
        }
        return cur;
    }
}
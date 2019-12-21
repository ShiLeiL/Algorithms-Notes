//题目：如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。
//给定一个代表每个房屋存放金额的非负整数数组，计算你在不触动警报装置的情况下，能够偷窃到的最高金额。
//例：输入: [1,2,3,1]
//   输出: 4

//这是第一次的提交记录
//执行用时108ms，超过89.47%的C#提交记录=v=
//通过官方题解的动态规划和f(k) = max(f(k – 2) + A_k, f(k – 1))的公式获得了思路
//选择了自上而下递归的方式进行计算

public class Solution 
{
    public int Rob(int[] nums) 
    {
        int[] result = new int[nums.Length];//建议一个备忘录
        //给备忘录标记其他值，并以此来判断该值是否计算出来过
        for(int i=0;i<nums.Length;i++) result[i]=-1;
        return UpDown(nums.Length - 1,nums,result);
    }
    
    static int UpDown(int n, int[] price,int[] result)
    {
        if (n < 0) return 0;
        if (result[n] != -1) return result[n]; //检查备忘录
        int maxPrice1 = price[n] + UpDown(n - 2, price,result); //公式比较值1
        int maxPrice2 = UpDown(n - 1, price,result); //公式比较值2
        result[n] = Math.Max(maxPrice1, maxPrice2); //把结果记录到备忘录
        return result[n];           
    }
}
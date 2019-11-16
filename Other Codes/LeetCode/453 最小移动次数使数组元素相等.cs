//这是第一次的提交记录
//执行用时148ms，超过100%的C#提交记录=v=
//思路是可以把题目转换为，每次移动让可以使1个元素减少1，求最小移动次数
//故只用求每个元素跟最小元素差多少的总和就可以了
//用两个变量来存储，一个存最小值，一个存所有数的总和，最后结果就等于总和减去n个最小值


public class Solution 
{
    public int MinMoves(int[] nums)
    {
        int min = nums[0], sum = 0;
        foreach (int i in nums) //遍历数组存储最小值并计算总和
        {
            if (i < min)
                min = nums[i];
            sum += nums[i];
        }
        return sum - nums.Length * min; //因为是计算差值总和，所以用元素总和减去n个最小值就可以了
    }
}
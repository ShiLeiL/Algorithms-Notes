//题目：在一个给定的数组nums中，总是存在一个最大元素 。
//查找数组中的最大元素是否至少是数组中每个其他数字的两倍。
//如果是，则返回最大元素的索引，否则返回-1。
//例：输入: nums = [3, 6, 1, 0]
//   输出: 1

//这是第一次的提交记录
//执行用时108ms，超过88.42%的C#提交记录=v=
//思路是用两个变量来存储，一个存最大值的下标，一个存第二大的数值
//遍历数组存储第一第二大的值，最后再对比第一是否比第二大两倍以上
//ps.为了节省执行用时，所以用了嵌套的if，正常思路是先判断是否大于最大值，否后再判断是否大于第二大值

public class Solution 
{
    public int DominantIndex(int[] nums)
    {
        int max = 0, maxtemp = -1;
        for (int i = 1; i < nums.Length; i++) 
        {
            if (nums[i] > maxtemp) 
            {
                if (nums[i] > nums[max]) //若大于最大值
                {
                    maxtemp = nums[max]; //把最大值赋给存储第二个变量
                    max = i; //把当前下标赋给第一个变量
                    continue; //直接进入下一轮循环
                }
                maxtemp = nums[i]; //若不大于最大值，则把值赋给第二个变量
            }
        }
        if (nums[max] < maxtemp * 2) //判断最大元素是否至少是第二大值的两倍
            return -1;
        return max;
    }
}
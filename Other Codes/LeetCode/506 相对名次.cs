//题目：给出 N 名运动员的成绩，找出他们的相对名次并授予前三名对应的奖牌。
//前三名运动员将会被分别授予 “金牌”，“银牌” 和“ 铜牌”（"Gold Medal", "Silver Medal", "Bronze Medal"）。
//例：输入:[5, 4, 3, 2, 1]
//   输出: ["Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"]

//这是第一次的提交记录
//执行用时324ms，超过94.74%的C#提交记录=v=
//思路是先获得数组的最大值，再建立一个以下标表示为分数的数组，用来记录每个分数在nums数组里的下标
//再倒序访问分数数组，并记录名次，若有下标，则给结果数组对应下标的位置记录名次，并名次+1
//PS.其实试过排序后再对照，但耗时太久了，估不做记录


public class Solution 
{
    public string[] FindRelativeRanks(int[] nums) 
    {
        int max = 0; 
        foreach (int num in nums)
            if (num > max) max = num; //找到nums的最大值
        int[] index = new int[max + 1]; //建立记录下标的分数数组
        for (int i = 0; i < nums.Length; i++) 
            index[nums[i]] = i + 1; //这里加一是为了区分下标为0和默认数值的区别
        string[] result = new string[nums.Length]; //结果数组
        result[index[max] - 1] = "Gold Medal"; //最大值必定是第一名
        for (int i = max - 1, rank = 2; i > -1; i--)
        {
            if (index[i] != 0) //若分数数组的记录下标不为0，则给其对应的结果数组添上名次
            {
                if (rank == 2) result[index[i] - 1] = "Silver Medal";
                else if (rank == 3) result[index[i] - 1] = "Bronze Medal";
                else result[index[i] - 1] = Convert.ToString(rank); 
                rank++; //名次+1
            }
        }
        return result;
    }
}
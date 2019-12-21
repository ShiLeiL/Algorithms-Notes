//题目：学校在拍年度纪念照时，一般要求学生按照 非递减 的高度顺序排列。
//请你返回至少有多少个学生没有站在正确位置数量。
//例：输入: [1,1,4,2,1,3]
//   输出: 3

//这是第二和第三次的提交记录
//执行用时108ms，超过89.58%的C#提交记录=v=
//第二次是思路是大佬的思路，用一个数字数组记录数字出现的次数
//再遍历原数组，根据数字出现的次数来对数字位置进行判断
//第三次是在大佬的思路上，把数字数组改成字典记录


//第二次
public class Solution 
{
    public int HeightChecker(int[] heights)
    {
        int[] arr = new int[101];
        foreach (int height in heights)
        {
            arr[height]++;
        }
        int count = 0;
        for (int i = 1, j = 0; i < arr.Length; i++)
        {
            while (arr[i]-- > 0)
            {
                if (heights[j++] != i) count++;
            }
        }
        return count;
    }
}


//第三次
public class Solution 
{
    public int HeightChecker(int[] heights)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (int i in heights)
        {
            if (dic.ContainsKey(i))
                dic[i]++;
            else dic.Add(i, 1);
        }
        dic = dic.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
        int count = 0, j = 0;
        List<int> temp = new List<int>(dic.Keys);
        for (int i = 0; i < temp.Count; i++)
        {
            while (dic[temp[i]]-- > 0)
            {
                if (heights[j++] != temp[i]) count++;
            }
        }
        return count;
    }
}
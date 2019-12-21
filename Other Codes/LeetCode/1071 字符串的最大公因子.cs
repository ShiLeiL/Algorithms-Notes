//题目：返回字符串 X，要求满足 X 能除尽 str1 且 X 能除尽 str2。
//例：输入: str1 = "ABCABC", str2 = "ABC"
//   输出: "ABC"

//这是第一次的提交记录
//执行用时84ms，超过100%的C#提交记录=v=
//思路先求两个字符串长度的最大公约数，则为最大公因子的长度
//再从一个字符串中，截取最大公约数的子串进行截取对比，若不相等则表示无公因子，直接返回

public class Solution 
{
    public string GcdOfStrings(string str1, string str2) 
    {
        int count = gcd(str1.Length, str2.Length); //获得最大公因子的长度
        if (count == 0) return ""; //若长度为0，说明没有公约数也就没有公因子
        string str = str1.Substring(0, count); //截取出一个公因子进行对比
        for (int i = count; i < str1.Length; i+=count) //对比字符串1
        {
            if (str1.Substring(i, count) != str)
                return "";
        }
        for (int i = 0; i < str2.Length; i += count) //对比字符串2
        {
            if (str2.Substring(i, count) != str)
                return "";
        }
        return str; //都匹配直接返回公因子
    }

    public static int gcd(int m, int n) //计算最大公约数
    {
        if (n == 0) return 0;
        while (m % n != 0)
        {
            int tmp = m % n;
            m = n;
            n = tmp;
        }
        return n;
    }
}
//题目：给定一个非空的字符串，判断它是否可以由它的一个子串重复多次构成。
//     给定的字符串只含有小写英文字母，并且长度不超过10000。
//例：输入:"abab"
//   输出: True

//这是第一次的提交记录
//执行用时104ms，超过100%的C#提交记录=v=
//思路是因为是判断是否由子串重复构成，故子串的首字母一定跟字符串一致
//所以我们先遍历一遍字符串，找到跟字符串首字母一致的字母的位置
//然后再根据这些记录的位置作为子串长度来判断是否符合条件


public class Solution 
{
    public bool RepeatedSubstringPattern(string s)
    {
        List<int> len = new List<int>(); //用于记录与首字母一致的字母位置的列表
        int lens = s.Length;
        for (int i = 1; i < lens; i++) //遍历字符串，记录len列表
        {
            if (s[i] == s[0])
                len.Add(i);
        }
        if (len.Count == 0) //没有与首字母一致的字母，直接返回false
            return false;
        else if (len.Count == lens - 1) //都与首字母一致，直接返回true
            return true;

        int j = 0;
        if (len[0] == 1) //若第二个字母与首字母一致，但又不是全部字母一致
            j = 1; //则从第二个与首字母一致的字母开始判断
        for (; j < len.Count && len[j] <= lens / 2; j++) 
        //若与首字母一致的字母位置在字符串后半部分，则就算重复一次长度也超出字符串长度，故直接退出循环
        {
            if (lens % len[j] != 0) continue; //若子串长度不能被字符串整除，也可直接排除
            string temp = s.Substring(1, len[j] - 1); //拿去掉首字母的子串进行对比
            for (int k = len[j] + 1; k < lens; k += len[j])
            {
                if (s.Substring(k, len[j] - 1) != temp) //若不相等，直接退出循环
                    break;
                else if (k == lens - len[j] + 1) //若都相等则返回true
                    return true;
            }
        }
        return false;
    }
}
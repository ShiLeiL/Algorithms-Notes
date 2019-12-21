//题目：给定一种规律 pattern 和一个字符串 str ，判断 str 是否遵循相同的规律。
//例：输入: pattern = "abba", str = "dog cat cat dog"
//   输出: true

//这是第一次的提交记录
//执行用时88ms，超过91.89%的C#提交记录=v=
//思路是用字典储存pattern和str之间的映射
//在遍历pattern的同时，对映射进行判断


public class Solution 
{
    public bool WordPattern(string pattern, string str)
    {
        string[] strList = str.Split(" "); //切分str
        if (pattern.Length != strList.Length) return false; //若pattern和str数量不对应，则直接说明不匹配
        Dictionary<char, string> dic = new Dictionary<char, string>();
        for (int i = 0; i < pattern.Length; i++)
        {
            if (!dic.ContainsKey(pattern[i])) //若字典中无pattern的字母，表示应该要添加新的字母和字符的映射
            {
                if (!dic.ContainsValue(strList[i])) //且字典中也无str的字符，则添加映射
                    dic.Add(pattern[i], strList[i]); 
                else return false; //要么字典中有str的字符，则表示不匹配，直接返回
            }
            else if (dic[pattern[i]] != strList[i]) //若字典中有pattern字母，则表示有对应映射了，直接把pattern字母对应的字符进行对比，若不相等就说明不匹配
                return false;
        }
        return true; //都匹配，返回匹配成功
    }
}
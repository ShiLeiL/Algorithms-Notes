//题目：给定一种规律 pattern 和一个字符串 str ，判断 str 是否遵循相同的规律。
//例：输入: pattern = "abba", str = "dog cat cat dog"
//   输出: true

//这是第二次的提交记录
//执行用时84ms，超过97.3%的C#提交记录=v=
//思路是同时对pattern和str进行遍历，判断当前字母和字符是否与前面的字母字符相等
//若相等关系相同，则表示匹配，反之则不匹配


public class Solution 
{
    public bool WordPattern(string pattern, string str)
    {
        string[] strList = str.Split(" ");
        if (pattern.Length != strList.Length) return false; //若pattern和str数量不对应，则直接说明不匹配         
        for(int i=1;i<pattern.Length;i++) //从第二个字母字符开始判断
        {
            for(int j=0;j<i;j++) //跟前面的字母字符进行对比
            {
                if (pattern[i] == pattern[j]) //若字母相等
                {
                    if (strList[i] != strList[j]) return false; //字符不相等，关系不同，不匹配
                    else break; //字符相等，关系相同，直接退出当前字母的对比循环
                }                       
                else if(strList[i] == strList[j]) //若字母不相等，字母相等，关系不同，不匹配
                    return false;
            }
        }
        return true;
    }
}
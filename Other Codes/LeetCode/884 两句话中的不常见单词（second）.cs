//题目：给定两个句子 A 和 B 。
//如果一个单词在其中一个句子中只出现一次，在另一个句子中却没有出现，那么这个单词就是不常见的。
//返回所有不常用单词的列表。
//例：输入: A = "this apple is sweet", B = "this apple is sour"
//   输出: ["sweet","sour"]

//这是第二次的提交记录
//执行用时284ms，超过100%的C#提交记录=v=
//思路是先把两个句子组合在一起，然后根据空格分隔遍历所有单词
//然后在建立两个列表，一个用来记录结果，一个用来记录重复的单词
//当遍历到的单词在两个表都不存在时，把单词加入记录结果的表
//ps.因为用了大佬的遍历思路，所以代码速度快了很多，跟我的想法没关系
//大佬的遍历思路是，直接访问每个字母，若遇到空格就表示前面是一整个单词

public class Solution 
{
    public string[] UncommonFromSentences(string A, string B)
    {
        List<string> temp1 = new List<string>(); //记录结果的表
        List<string> temp2 = new List<string>(); //记录重复单词的表
        string s = A + " " + B + " "; //句子合并
        string t = null; //记录当前单词
        for (int i = 0; i < s.Length; i++) //遍历每个字母
        {
            if (s[i] == ' ') //如果遍历到空格，则判断单词
            {
                if (!temp1.Contains(t) && !temp2.Contains(t)) //单词在两个表都不存在，加入表1
                    temp1.Add(t);
                else if (temp1.Contains(t)) //单词存在于表1，则表示单词重复了
                {
                    temp1.Remove(t); //从表1删除单词
                    temp2.Add(t); //把单词加入记录重复的表2
                }
                t = null; //重置当前单词记录
            }
            else //不是空格，则表示还不是一整个单词
                t += s[i]; 
        }
        return temp1.ToArray();
    }
}
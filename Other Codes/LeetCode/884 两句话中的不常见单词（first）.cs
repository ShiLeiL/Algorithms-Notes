//这是第一次的提交记录
//执行用时292ms，超过81.78%的C#提交记录=0=
//思路是先把两个句子组合在一起，然后根据空格分隔遍历所有单词
//用字典来记录每个单词出现的次数，最后输出出现次数为1的单词

public class Solution 
{
    public string[] UncommonFromSentences(string A, string B)
    {
        Dictionary<string, int> d = new Dictionary<string, int>(); //创建字典
        foreach (string i in (A + " " + B).Split(" ")) //合并句子，根据空格分隔遍历所有单词
        {
            if (!d.ContainsKey(i)) //若字典里没单词，把单词加入字典
                d.Add(i, 1);
            else d[i]++; //若有，则次数加一
        }
        List<string> result = new List<string>();
        foreach (KeyValuePair<string, int> kvp in d) //遍历字典
        {
            if (kvp.Value == 1) //若单词只出现一次，则加入结果列表
                result.Add(kvp.Key);
        }
        return result.ToArray();
    }
}
//这是第一次的提交记录
//执行用时84ms，超过100%的C#提交记录=v=
//思路是用KMP模式匹配改进算法进行更改
//添加times叠加次数和maxtimes最大叠加次数判断
//其中maxtimes的根据是，B至少与A在第一次叠加时有一个字母重叠
//那么当B的长度-1后，整除a的长度再加上第一次和最后一次叠加的次数就是最大叠加次数
//当叠加次数已经超过最大叠加次数，则表明匹配失败

public class Solution {
    public int RepeatedStringMatch(string A, string B) 
    {
        int i = 0; //A的指针
        int j = 0; //B的指针
        int times = 1; //叠加次数
        int maxtimes = (B.Length-1)/A.Length+2; //最大叠加次数
        int[] next = getNext(B);
        while (i < A.Length+1 && j < B.Length)
        {
            if(i==A.Length) //若超过A的边界，则叠加
            {
                i = 0;
                times++;
            }
            if (j == -1 || A[i] == B[j])
            {
                i++; j++;
            }
            else if (times > maxtimes) //当次数超过最大叠加次数时，则判为B不为A叠加后的子串
                return -1;
            else j = next[j];
        }
        return times;
    }
    
    //获取KMP的next数组，详请查询KMP
    public static int[] getNext(string T)
    {
        int i = 0;
        int j = -1;
        int[] next = new int[T.Length];
        next[0] = -1;
        while (i < T.Length - 1)
        {
            if (j == -1 || T[i] == T[j])
            {
                i++;j++;
                if (T[i] != T[j])
                    next[i] = j;
                else
                    next[i] = next[j];
            }
            else
                j = next[j];
        }
        return next;
    }
}
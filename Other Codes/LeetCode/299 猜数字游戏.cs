//这是第一次的提交记录
//执行用时100ms，超过100%的C#提交记录=v=
//思路是先遍历一次数字，若相等，则删掉相等的数并记一次公牛
//之后再遍历一次删除后的数字，若存在相等的数，则同样删掉数，记一次奶牛

public class Solution {
    public string GetHint(string secret, string guess)
    {
        int countA = 0, countB = 0;
        for (int i = 0; i < guess.Length; i++) //第一次遍历
        {
            if (secret[i] == guess[i])
            {
                countA++; //记一次公牛
                secret = secret.Remove(i, 1); //删掉相同的数字
                guess = guess.Remove(i--, 1);
            }
        }
        for (int i = 0; i < guess.Length; i++) //第二次遍历
        {
            if (secret.Contains(guess[i])) 
            {
                countB++; //记一次奶牛
                secret = secret.Remove(secret.IndexOf(guess[i]), 1); //删掉相同的数字
            }
        }
        return countA + "A" + countB + "B";
    }
}
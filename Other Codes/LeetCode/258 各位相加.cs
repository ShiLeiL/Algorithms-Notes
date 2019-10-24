//这是第一次的提交记录
//执行用时44ms，超过93.55%的C#提交记录=v=
//思路是有个除以9的规律，当除以9为0时，最后结果为9
//当除以9有余时，最后结果为余数

public class Solution 
{
    public int AddDigits(int num) 
    { 
        if (num == 0) return 0;
        int mod = num % 9;
        if (mod == 0) return 9;
        else return mod;
    }
}
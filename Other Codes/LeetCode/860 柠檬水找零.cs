//这是第一次的提交记录
//执行用时116ms，超过100%的C#提交记录=v=
//思路是创建两个变量来记录5美元和10美元的持有数量
//当顾客支付5美元时，5美元持有量加一
//当顾客支付10美元时，10美元持有量加一，但因为要找零，所以5美元的持有量减一
//当顾客支付20美元时，要么使用一张10美元和一张5美元找零，要么使用三张5美元找零

public class Solution 
{
    public bool LemonadeChange(int[] bills)
    {
        int changeF = 0, changeT = 0; //持有量记录
        for (int i = 0; i < bills.Length; i++)
        {
            if (bills[i] == 5) changeF++; //若支付5美元，5美元持有量加一
            else if (bills[i] == 10) //若支付10美元，10美元持有量加一，5美元持有量减一
            {
                changeF--;
                changeT++;
            }
            else if (changeT > 0) //若支付20美元且10美元持有量至少有1，则使用一张10美元和一张5美元找零
            {
                changeT--;
                changeF--;
            }
            else changeF -= 3; //以上情况都不满足，则使用三张5美元找零
            if (changeF < 0 || changeT < 0) //当持有量为负数，则表示没有足够的零钱找零
                return false;
        }
        return true;
    }
}
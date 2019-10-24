//这是第一次的提交记录
//执行用时296ms，超过99.54%的C#提交记录=v=
//思路是遍历数组当有非0的数则与指针指向的数进行交换（前挪）
//最后把0添回数组

public class Solution 
{
    public void MoveZeroes(int[] nums) 
    {
        int lo = 0; //指针
        for (int i = 0; i < nums.Length; i++) //把非0的数位置挪向前
        {
            if (nums[i] != 0)
                nums[lo++] = nums[i];
        }
        for (int i = lo; i < nums.Length; i++) //补回0
            nums[i] = 0;
    }
}
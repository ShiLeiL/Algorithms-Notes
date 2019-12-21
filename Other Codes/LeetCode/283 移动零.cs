//题目：给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。
//例：输入: [0,1,0,3,12]
//   输出: [1,3,12,0,0]

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
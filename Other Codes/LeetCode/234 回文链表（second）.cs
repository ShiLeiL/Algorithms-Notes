//这是第二次的提交记录
//执行用时124ms，超过70%的C#提交记录=v=
//思路是用栈来储存链表前半部分的值，并用快指针找到中点
//过了中点后，再输出栈的值来进行对比

public class Solution 
{
    public bool IsPalindrome(ListNode head) 
    {
        ListNode fast = head; //快指针
        Stack<int> temp = new Stack<int>(); //存值栈
        while (fast != null && fast.next != null)
        {
            temp.Push(head.val); //把前半部分的值存入栈里
            fast = fast.next.next;
            head = head.next;
        }
        if(fast !=null) head = head.next; //单数验证
        while (temp.Count != 0) //校验
        {
            if (temp.Pop() != head.val) //当栈顶的值与后面的值不相等，返回错误
                return false;
            head = head.next;
        }
        return true;
    }
}
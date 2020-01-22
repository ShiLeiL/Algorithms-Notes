//题目：删除链表中等于给定值 val 的所有节点。
//例：输入:1->2->6->3->4->5->6, val = 6
//   输出: 1->2->3->4->5

//这是第一次的提交记录
//执行用时120ms，超过83.87%的C#提交记录=0=
//思路是先建立一个值为val的last节点指向head，然后对这个节点的下一个节点的值进行判断
//当下一个节点的值为val时，把last.next的指向改为指向下下个节点
//并判断删除的是否为头节点，若是，则把last.next设为新的头结点

public class Solution 
{
    public static ListNode RemoveElements(ListNode head, int val)
    {
        ListNode last = new ListNode(val); 
        last.next = head;
        while (last != null && last.next != null) 
        {
            if (last.next.val == val) 
            {
                last.next = last.next.next; //删除节点
                if (last.val == val) //通过last的值来判断last指向是否移动，从而判断是否删除头节点
                    head = last.next; //若删除，则把last.next设为新的头结点
            }
            else last = last.next; //不等于val值则继续遍历
        }
        return head;
    }
}
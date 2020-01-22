//题目：删除链表中等于给定值 val 的所有节点。
//例：输入:1->2->6->3->4->5->6, val = 6
//   输出: 1->2->3->4->5

//这是第二次的提交记录
//执行用时108ms，超过98.92%的C#提交记录=v=
//这是用大佬的思路做了修改进而得出来的代码，觉得是一种新思路，做个记录
//思路是先建立一个用于储存结果的新链表
//遍历head链表，若值等于val，则跳过该节点

public class Solution 
{
    public static ListNode RemoveElements(ListNode head, int val)
    {
        ListNode newHead = new ListNode(0); //新链表
        ListNode previousNode = newHead; //新链表的指针
        while (head != null)
        {
            if (head.val != val)
            {
                previousNode.next = head; //让pre尾部指向跳过节点后的head，相当于添加一个非val的值的节点
                previousNode = head; //让pre指向pre的下一个节点，也就是head
            }
            head = head.next; //遍历下一个节点
        }
        previousNode.next = null; //若尾部节点的值等于val，不会跳过，故直接删除
        return newHead.next;
    }
}

//代码也可以改成，会更好理解
//    if (head.val != val)
//    {
//        previousNode.next = new ListNode(head.val); 
//        previousNode = previousNode.next; 
//    }
//运行时间是一样的，就是运存会多一些，仅限于简单结构的node
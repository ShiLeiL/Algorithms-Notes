//题目：请判断一个链表是否为回文链表。
//例：输入: 1->2->2->1
//   输出: true

//这是大佬的算法，符合题目进阶的O(n) 时间复杂度和 O(1) 空间复杂度的要求
//执行用时172ms，略久但很厉害
//思路是利用快慢指针，在遍历的同时翻转前半部分的链表
//之后再做回文验证

public class Solution 
{
    public bool IsPalindrome(ListNode head) 
    {
        if (head == null || head.next == null) //空白验证
            return true;
        ListNode slow = head, fast = head.next, pre = null, prepre = null;
        while (fast != null && fast.next != null)
        {
            pre = slow;
            slow = slow.next;
            fast = fast.next.next; //快指针
            pre.next = prepre; //同事翻转
            prepre = pre;
        }
        ListNode p2 = slow.next;
        slow.next = pre;
        if (fast == null) //单数验证
            slow = slow.next;
        while (slow != null) //回文校验
        {
            if (slow.val != p2.val)
                return false;
            slow = slow.next;
            p2 = p2.next;
        }
        return true;        
    }
}
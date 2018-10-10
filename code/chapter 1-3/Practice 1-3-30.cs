public static Node Reverse(Node first)
{
    /* 算法（第四版） 1.3.30 */
    //与书上的思路有一点不一样
    //书上是通过存储去掉头结点的链表进行循环
    //直接取链表的头结点并把该结点的next指向上一轮做出的reverse
    //而我是通过遍历链表进行循环
    //把当前结点的值赋给新的reverse的头结点
    //并让其next指向上一轮的reverse
    //虽然没有书上简便，但是这是自己的思路
    Node reverse = first;
    first = first.next;
    reverse.next = null;
    while (first!=null)
    {
        Node oldreverse = reverse;
        reverse = new Node();
        reverse.item = first.item;
        reverse.next = oldreverse;
        first = first.next;
    }
    return reverse;
}
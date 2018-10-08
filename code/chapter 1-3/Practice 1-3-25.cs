public void insertAfter(Node a,Node b)
{
    /* 算法（第四版） 1.3.25 */
    if (a == null || b == null)
        return;
    Node temp = first;
    while (true)
    {
        if (temp == null)
            break;
        if (temp.item.Equals(a.item))
            if (temp.next == a.next)
            {
                b.next = a.next;
                a.next = b;
                return;
            }
        temp = temp.next;
    }
}
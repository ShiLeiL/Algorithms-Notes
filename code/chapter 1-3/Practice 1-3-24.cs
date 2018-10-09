public void removeAfter(Node a)
{
    /* 算法（第四版） 1.3.24 */            
    if (a.next == null || a.item == null)
        return;
    Node temp = first;
    while (temp != null)
    {
        if (temp.item.Equals(a.item))
            if(temp.next.Equals(a.next))
            {
                Node temp1 = temp.next;
                temp.next = temp.next.next;
                temp1 = null;
                return;
            }
        temp = temp.next;
    }
}
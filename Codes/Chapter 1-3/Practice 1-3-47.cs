/* 算法（第四版） 1.3.47 */
//数组队列链接
public void catenation(Queue<T> supplement)
{
    if (isEmpty())
    {
        a = supplement.a;
        N = supplement.N;
    }
    else if (supplement.isEmpty())
        return;
    else
    {
        while (supplement.peek() != null)
            enqueue(supplement.dequeue());
    }
}

//链表队列和steque链接
public void catenation(Queue<T> supplement)
{
    if (isEmpty())
    {
        first = supplement.first;
        N = supplement.size();
    }
    else if (supplement.isEmpty())
        return;
    else
    {
        last.next = supplement.first;
        N = N + supplement.size();
        last = supplement.last;
    }
}

//栈链接
public void catenation(Stack<Item> supplement)
{
    if (isEmpty())
    {
        first = supplement.first;
        N = supplement.size();
    }
    else if (supplement.isEmpty())
        return;
    else
    {
        Node temp = supplement.first;
        while (temp.next != null)
            temp = temp.next;
        temp.next = first;
        first = supplement.first;
        N += supplement.size();
    }
}
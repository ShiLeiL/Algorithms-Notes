public class QueueOfCircularChain<T>
{
    /* 算法（第四版） 1.3.29 */
    private Node last;
    private int N = 0;//标记链表个数用，方便调试，与题目无关

    public class Node
    {
        public T item;
        public Node next;
    }

    public bool isEmpty()
    { return last== null; }

    public int size()
    { return N; }

    public T peek()
    {
        if (isEmpty())
            throw new Exception();
        return last.item;
    }

    public void enqueue(T item)
    {
        //将元素添加到队尾
        Node oldlast = last;
        last = new Node();
        last.item = item;
        if (oldlast==null)
            last.next = last;            
        else
        {
            last.next = oldlast.next;
            oldlast.next = last;
        }               
        N++;
    }

    public T dequeue()
    {
        if (isEmpty())
            throw new Exception();
        T item = last.next.item;
        if (last.next == last)
            last = null;
        else last.next = last.next.next;
        N--;
        return item;
    }

    public string toString()
    {
        string s = Convert.ToString(last.next.item);
        Node temp = last.next.next;
        while(temp!=last.next)
        {
            s = s + Convert.ToString(temp.item);
            temp = temp.next;
        }
        return s;
    }
}
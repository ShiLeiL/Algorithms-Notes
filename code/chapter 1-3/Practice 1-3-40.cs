namespace AlgorithmsApplication
{
    public class MoveToFront<T>
    {
        /* 算法（第四版） 1.3.40 */
        private Node first;
        private Node last;
        private int N = 0;

        public class Node
        {
            public T item;
            public Node next;
        }

        //读取一串数据
        public void add(T[] toAdd)
        {
            foreach (T i in toAdd)
                InsertFirst(i);
        }

        //在表头插入结点
        public void InsertFirst(T item)
        {
            Find(item);
            Node oldfirst = first;
            first = new Node();
            first.item = item;
            if (oldfirst == null)
                last = first;
            else
                first.next = oldfirst;
            N++;
        }

        //表中是否存在key，若存在则删除
        public void Find(T item)
        {
            if (first == null)
                return;
            else if (first.item.Equals(item))
            {
                first = first.next;//若两方法合并，则可删除去句，若第一个就为key时，相对操作就会少一些
                N--;
                return;
            }
            Node temp = first.next;
            Node previous = first;
            while (temp != null)
            {
                if (temp.item.Equals(item))
                {
                    previous.next = previous.next.next;
                    if (temp.next == null)
                        last = previous;
                    N--;
                    break;
                }
                previous = temp;
                temp = temp.next;
            }
        }
    }
}
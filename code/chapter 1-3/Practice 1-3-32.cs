namespace AlgorithmsApplication
{
    public class Steque<T>
    {
        /* 算法（第四版） 1.3.32 */
        //我所理解的题目意思是该队列即可以当栈也可以当队列
        //故以push把元素添加到队头的方法来达到效果
        private Node first;//队头
        private Node last;//队尾
        private int N = 0;//元素数量

        private class Node
        {
            //定义了结点的嵌套类
            public T item;
            public Node next;
        }

        public Steque()
        {
            first = null;
            last = null;
            N = 0;
        }

        public bool isEmpty()
        { return first == null; }

        public int size()
        { return N; }

        public T peek()
        //获取队头元素
        { return first.item; }
        
        public T dequeue()
        {
            //从队头删除元素
            T item = first.item;
            first = first.next;
            N--;
            if (isEmpty())
                last = null;
            return item;
        }

        //1.3.32部分
        public void push(T item)
        {
            Node oldfirst = first;
            first = new Node();
            first.item = item;
            if (isEmpty())
                last = first;
            else first.next = oldfirst;
            N++;
        }

        public T pop()
        { return first.item; }

        public void enqueue(T item)
        {
            //将元素添加到队尾
            Node oldlast = last;
            last = new Node();
            last.item = item;
            last.next = null;
            if (isEmpty())
                first = last;
            else oldlast.next = last;
            N++;
        }
    }
}
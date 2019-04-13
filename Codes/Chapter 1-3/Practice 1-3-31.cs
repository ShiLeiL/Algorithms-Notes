using System;

namespace AlgorithmsApplication
{
    public class DoubleNode<T>
    {
        /* 算法（第四版） 1.3.31 */
        private Node first;
        private Node last;
        private int N = 0;

        public class Node
        {
            public T item;
            public Node next;
            public Node previous;
        }

        //在表头插入结点
        public void InsertFirst(T item)
        {
            Node oldfirst = first;
            first = new Node();
            first.item = item;
            if (oldfirst == null)
                last = first;
            else
            {
                first.next = oldfirst;
                oldfirst.previous = first;
            }               
            N++;
        }

        //在表尾插入结点
        public void InsertLast(T item)
        {
            Node oldlast = last;
            last = new Node();
            last.item = item;
            if (oldlast == null)
                first = last;
            else
            {
                oldlast.next = last;
                last.previous = oldlast;
            }               
            N++;
        }

        //从表头删除结点
        public T DelectFirst()
        {
            if (first == null)
                throw new Exception();
            T item = first.item;
            first = first.next;
            N--;
            if (N == 0)
                last = null;
            else first.previous = null;
            return item;
        }

        //从表尾删除结点
        public T DelectLast()
        {
            if (last == null)
                throw new Exception();
            T item = last.item;
            last = last.previous;
            N--;
            if (N == 0)
                first = null;
            else last.next = null;
            return item;
        }

        //在指定结点之前插入新结点
        public void InsertFront(T key,T item)
        {
            Node temp = first;
            while (!temp.item.Equals(key))
            {
                temp = temp.next;
                if (temp == null)
                    throw new Exception();
            }
            Node oldtemp = temp;
            temp = new Node();
            temp.item = item;
            temp.next = oldtemp;
            temp.previous = oldtemp.previous;
            temp.previous.next = temp;
            oldtemp.previous = temp;
            N++;
        }

        //在指定结点之后插入新结点
        public void InsertAfter(T key,T item)
        {
            Node temp = first;
            while (!temp.item.Equals(key))
            {
                temp = temp.next;
                if (temp == null)
                    throw new Exception();
            }               
            Node oldtemp = temp.next;
            temp = new Node();
            temp.item = item;
            temp.next = oldtemp;
            temp.previous = oldtemp.previous;
            temp.previous.next = temp;
            oldtemp.previous = temp;
            N++;
        }

        //删除指定结点
        public T DelectAppointed(T key)
        {
            if (last == null)
                throw new Exception();
            T item = key;
            if (N == 1)
            {
                first = null;
                last = null;
            }
            else
            {
                Node temp = first;
                while (!temp.item.Equals(key))
                {
                    temp = temp.next;
                    if (temp == null)
                        throw new Exception();
                }
                temp.previous.next = temp.next;
                temp.next.previous = temp.previous;
            }
            N--;
            return item;
        }       
    }
}
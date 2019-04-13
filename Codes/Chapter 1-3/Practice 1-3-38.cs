using System;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.3.38 */
    //用数组实现
    public class GeneralizedQueue1<T>
    { 
        private T[] a;
        private int N = 0;

        public GeneralizedQueue1()
        {
            a = new T[10];
            N = 0;
        }

        private void resize(int capacity)
        {
            //将栈移动到一个大小为capacity的新数组
            T[] temp = new T[capacity];
            for (int i = 0; i < N + 1; i++)
                temp[i] = a[i];
            a = temp;
        }

        public bool isEmpty()
        { return N == 0; }

        public void insert(T x)
        {
            if (N == a.Length - 1)
                resize(2 * a.Length);
            a[N++] = x;
        }

        public T delete(int k)
        {
            if (k > N)
                throw new Exception();
            T temp = a[k - 1];
            for (int i = k - 1; i < N; i++)
                a[i] = a[i + 1];
            N--;
            return temp;
        }
    }

    //用链表实现
    public class GeneralizedQueue2<T>
    {
        private Node first;//队头
        private Node last;//队尾
        private int N = 0;//元素数量

        private class Node
        {
            //定义了结点的嵌套类
            public T item;
            public Node next;
        }

        public GeneralizedQueue2()
        {
            first = null;
            N = 0;
        }

        public bool isEmpty()
        { return N == 0; }

        public void insert(T x)
        {
            Node oldlast = last;
            last = new Node();
            last.item = x;
            last.next = null;
            if (isEmpty())
                first = last;
            else oldlast.next = last;
            N++;
        }

        public T delete(int k)
        {
            if (k > N)
                throw new Exception();
            if(N==1)
            {
                T temp3 = first.item;
                first = null;
                last = null;
                N--;
                return temp3;
            }
            Node temp = first;
            for (int i = 1; i < k; i++)
                temp = temp.next;
            T temp1 = temp.item;
            temp.next = temp.next.next;
            N--;
            return temp1;
        }
    }
}
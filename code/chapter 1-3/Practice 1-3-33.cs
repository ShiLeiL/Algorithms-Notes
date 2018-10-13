using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.3.33 */
    //双向链表实现
    public class Deque<T> : IEnumerable<T>
    {
        private Node first;
        private Node last;
        private int N = 0;

        public class Node
        {
            public T item;
            public Node next;
            public Node previous;
        }

        public Deque()
        {
            first = null;
            last = null;
            N = 0;
        }

        public bool isEmpty()
        { return N == 0; }

        public int size()
        { return N; }

        //向左端添加一个新元素
        public void pushLeft(T item)
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

        //向右端添加一个新元素
        public void pushRight(T item)
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

        //从左端删除一个元素
        public T popLeft()
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

        //从右端删除一个元素
        public T popRight()
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

        public IEnumerator<T> GetEnumerator()
        { return new DequeEnumerator(first); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        public bool Equals(T other)
        {
            throw new NotImplementedException();
        }

        class DequeEnumerator : IEnumerator<T>
        {
            //枚举器
            private Node current;
            private Node first;

            public DequeEnumerator(Node first)
            {
                current = new Node();
                current.next = first;
                this.first = current;
            }

            public T Current
            {
                get { return current.item; }
            }

            object IEnumerator.Current
            {
                get { return current.item; }
            }

            void IDisposable.Dispose()
            {
                current = null;
                first = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (current.next == null)
                    return false;

                current = current.next;
                return true;
            }

            void IEnumerator.Reset()
            {
                current = first;
            }
        }
    }

    //动态数组实现
    public class ResizingArrayDeque<T> : IEnumerable<T>
    {
        private T[] a;
        private int N = 0;

        public ResizingArrayDeque()
        {
            a = new T[5];
            N = 0;
        }

        public bool isEmpty()
        { return N == 0; }

        public int size()
        { return N; }

        private void resize(int capacity, int position)
        {
            //将栈移动到一个大小为capacity的新数组
            T[] temp = new T[capacity];
            for (int i = 0; i < N + 1; i++)
                temp[i] = a[i + position];
            a = temp;
        }

        //向左端添加一个新元素
        public void pushLeft(T item)
        {
            if (N == a.Length - 1)
                resize(2 * a.Length, 0);
            T[] temp = new T[a.Length];
            temp[0] = item;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] == null)
                    break;
                temp[i] = a[i - 1];
            }
            a = temp;
            N++;
        }

        //向右端添加一个新元素
        public void pushRight(T item)
        {
            if (N == a.Length - 1)
                resize(2 * a.Length, 0);
            a[N++] = item;
        }

        //从左端删除一个元素
        public T popLeft()
        {
            if (N == 0)
                throw new Exception();
            T temp = a[0];
            a[0] = default(T);
            N--;
            if (N > 0 && N == a.Length / 4)
                resize(a.Length / 2, 1);
            else resize(a.Length, 1);
            return temp;
        }

        //从右端删除一个元素
        public T popRight()
        {
            if (N == 0)
                throw new Exception();
            T temp = a[N - 1];
            a[N - 1] = default(T);
            N--;
            if (N > 0 && N == a.Length / 4)
                resize(a.Length / 2, 1);
            else resize(a.Length, 0);
            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        { return new DequeEnumerator(a,N); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        class DequeEnumerator : IEnumerator<T>
        {
            //枚举器
            private T[] _a;
            private int position = -1;
            private int N;

            public DequeEnumerator(T[] theDeque,int theN)
            {
                _a = new T[theDeque.Length];
                for (int i = 0; i < theDeque.Length; i++)
                    _a[i] = theDeque[i];
                N = theN;
            }

            public T Current
            {
                get { return _a[position]; }
            }

            object IEnumerator.Current
            {
                get { return _a[position]; }
            }
            void IDisposable.Dispose()
            {
                _a = default(T[]);
                position = -1;
            }

            bool IEnumerator.MoveNext()
            {
                if (position < N-1)
                {
                    position++;
                    return true;
                }
                return false;
            }

            void IEnumerator.Reset()
            {
                position = -1;
            }
        }
    }
}
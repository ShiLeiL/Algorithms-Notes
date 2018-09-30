using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    public class ResizingArrayQueueOfTs<T> : IEnumerable<T>
    {
        /* 算法（第四版） 1.3.14 */
        private T[] a;
        private int N;

        public ResizingArrayQueueOfTs(int capacity)
        {
            a = new T[capacity];
            N = 0;
        }

        public bool isEmpty()
        { return N == 0; }

        public int size()
        { return N; }

        private void resize(int capacity,int position)
        {
            //将栈移动到一个大小为capacity的新数组
            T[] temp = new T[capacity];
            for (int i = 0; i < N+1; i++)
                temp[i] = a[i+position];
            a = temp;
        }

        public void enqueue(T item)
        {
            //将元素添加到队尾
            if (N == a.Length-1)
                resize(2 * a.Length,0);
            a[N++] = item;
        }

        public T dequeue()
        {
            //从队头删除元素
            T temp = a[0];
            a[0] = default(T);
            N--;
            if (N > 0 && N == a.Length / 4)
                resize(a.Length / 2, 1);
            else resize(a.Length, 1);
            return temp;
        }

        public T peek()
        { return a[N - 1]; }

        public IEnumerator<T> GetEnumerator()
        { return new QueueEnumerator(a); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        class QueueEnumerator : IEnumerator<T>
        {
            //枚举器
            private T[] _a;
            private int position;

            public QueueEnumerator(T[] theQueue)
            {
                _a = new T[theQueue.Length];
                for (int i = 0; i < theQueue.Length; i++)
                    _a[i] = theQueue[i];
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
                if (position < _a.Length - 1)
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
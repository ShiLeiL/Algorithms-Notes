using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.3.35 */
    public class RandomQueue<T> : IEnumerable<T>
    {
        private T[] a;
        private int N = 0;

        public RandomQueue()
        {
            a = new T[5];
            N = 0;
        }

        public bool isEmpty()
        { return N == 0; }

        public int size()
        { return N; }

        private void resize(int capacity)
        {
            //将栈移动到一个大小为capacity的新数组
            T[] temp = new T[capacity];
            for (int i = 0; i < N + 1; i++)
                temp[i] = a[i];
            a = temp;
        }

        //添加一个元素
        public void enqueue(T item)
        {
            if (N == a.Length - 1)
                resize(2 * a.Length);
            a[N++] = item;
        }

        //删除并随机返回一个元素
        public T dequeue()
        {
            if (N == 0)
                throw new Exception();
            Random r = new Random();
            int num = r.Next(N - 1);
            T temp = a[num];
            a[num] = a[N - 1];
            a[N - 1] = default(T);
            N--;
            if (N > 0 && N == a.Length / 4)
                resize(a.Length / 2);
            return temp;
        }

        public T sample()
        {
            Random r = new Random();
            return a[r.Next(N - 1)];
        }
    }
}
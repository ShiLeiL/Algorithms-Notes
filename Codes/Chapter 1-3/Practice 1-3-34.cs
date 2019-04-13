using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.3.34 */
    public class RandomBag<T> : IEnumerable<T>
    {
        private T[] a;
        private int N = 0;

        public RandomBag()
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

        public void add(T item)
        {
            if (N == a.Length - 1)
                resize(2 * a.Length);
            a[N++] = item;
        }

        public IEnumerator<T> GetEnumerator()
        { return new RandomBagEnumerator(a, N); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        class RandomBagEnumerator : IEnumerator<T>
        {
            private T[] _a;
            private int position = -1;
            private string temp = "";//已输出的随机数临时容器
            private Random rd = new Random();
            private int num;//用于存放当前随机数
            private int N;

            public RandomBagEnumerator(T[] theRandomBag, int theN)
            {
                _a = new T[theRandomBag.Length];
                for (int i = 0; i < theRandomBag.Length; i++)
                    _a[i] = theRandomBag[i];
                N = theN;
            }

            public T Current => _a[num];
            object IEnumerator.Current => _a[num];

            void IDisposable.Dispose()
            {
                _a = default(T[]);
                position = -1;
            }

            bool IEnumerator.MoveNext()
            {
                while (position < N)
                {
                    num = rd.Next(N);
                    if (temp.IndexOf(num.ToString()) >= 0)
                        continue;
                    else
                    {
                        temp += num.ToString();
                        position++;
                        return true;
                    }
                }
                return false;
            }

            void IEnumerator.Reset()
            {
                position = -1;
                temp = "";
            }
        }
    }
}
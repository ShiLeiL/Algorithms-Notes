using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.3.49 */
    //自己写的方法有个缺陷
    //当连续操作添加元素操作超过limit*2次时
    //s3就会添加两组数据，会导致数组排序错误
    //若有更好的方法望指教！
    public class StackForQueue<T>
    {
        Stack<T> s1, s2, s3;
        int N;

        public StackForQueue()
        {
            s1 = new Stack<T>();//输出栈
            s2 = new Stack<T>();//输入栈
            s3 = new Stack<T>();//缓冲栈
        }

        //判断是否为空
        public bool IsEmpty()
        { return N == 0; }

        //个数
        public int Size()
        { return N; }

        //添加一个元素
        public void enqueue(T item)
        {
            int limit = 5;//界限
            s2.Push(item);
            if (s2.Count == limit)
            {
                for (int i = 0; i < limit; i++)
                    s3.Push(s2.Pop());
            }
            N++;
        }

        //删除一个元素
        public T dequeueu()
        {
            T temp;
            if (IsEmpty())
                throw new Exception();
            else if (s1.Count==0)
            {
                if (s3.Count == 0)
                {
                    int tempN = s2.Count;
                    for (int i = 0; i < tempN; i++)
                        s1.Push(s2.Pop());
                }                    
                else
                {
                    s1 = s3;
                    s3 = new Stack<T>();
                }
            }
            temp = s1.Pop();
            N--;
            return temp;
        }
    }
}
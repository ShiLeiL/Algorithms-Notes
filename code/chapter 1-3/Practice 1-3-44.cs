using System;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    public class Buffer
    {
        /* 算法（第四版） 1.3.44 */
        public Stack<char> leftSide;
        public Stack<char> rightSide;

        //创建一块空缓冲区
        public Buffer()
        {
            leftSide = new Stack<char>();
            rightSide = new Stack<char>();
        }

        //在光标位置插入字符c
        public void insert(char c)
        { leftSide.Push(c); }

        //删除并返回光标位置的字符
        public char delete()
        { return leftSide.Pop(); }

        //将光标向左移动k个位置
        public void left(int k)
        {
            if (k > leftSide.Count)
                throw new Exception();
            char temp;
            for(int i=0;i<k;i++)
            {
                temp = rightSide.Pop();
                leftSide.Push(temp);
            }
        }

        //将光标向右移动k个位置
        public void right(int k)
        {
            if (k > rightSide.Count)
                throw new Exception();
            char temp;
            for (int i = 0; i < k; i++)
            {
                temp = leftSide.Pop();
                rightSide.Push(temp);
            }
        }

        //缓冲区中的字符数量
        public int size()
        { return leftSide.Count + rightSide.Count; }
    }
}
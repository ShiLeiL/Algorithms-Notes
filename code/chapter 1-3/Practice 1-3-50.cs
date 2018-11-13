using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    public class Stack<Item> : IEnumerable<Item>
    {
        /* 算法（第四版） 1.3.50 */
        private Node first;//栈顶（最近添加的元素）
        private int N = 0;//元素数量
        private int popCount = 0;
        private int pushCount = 0;

        private class Node
        {
            //定义了结点的嵌套类
            public Item item;
            public Node next;
        }

        public bool isEmpty()
        { return first == null; }

        public int size()
        { return N; }

        public void push(Item item)
        {
            //向栈顶添加元素
            Node oldfirst = first;
            first = new Node();
            first.item = item;
            first.next = oldfirst;
            N++;
            pushCount++;
        }

        public Item pop()
        {
            //从栈顶删除元素
            Item item = first.item;
            first = first.next;
            N--;
            popCount++;
            return item;
        }

        public IEnumerator<Item> GetEnumerator()
        { return new StackEnumerator(this); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        class StackEnumerator : IEnumerator<Item>
        {
            //枚举器
            private Stack<Item> temps;
            private Node current;
            private Node first;
            private int popCount, pushCount;

            public StackEnumerator(Stack<Item> s)
            {
                temps = s;
                current = new Node();
                current.next = s.first;
                this.first = current;
                popCount = s.popCount;
                pushCount = s.pushCount;
            }

            public Item Current
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
                popCount = 0;
                pushCount = 0;
            }

            bool IEnumerator.MoveNext()
            {
                if(temps.popCount!=popCount||temps.pushCount!=pushCount)
                    throw new InvalidOperationException("Stack has been modified");

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
}
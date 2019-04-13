using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.3.4 */
            string inP = Console.ReadLine();
            Stack<string> a = new Stack<string>();
            for(int i=0;i<inP.Length;i++)
            {
                string item = inP.Substring(i, 1);
                if (item == "(" || item == "[" || item == "{")
                    a.push(item);
                else if (item == ")" || item == "]" || item == "}")
                    a.pop();
            }
            if (a.isEmpty()) Console.WriteLine("true");
            else Console.WriteLine("false");
            Console.ReadKey();
        }
    }

    public class Stack<Item>:IEnumerable<Item>
    {
        private Node first;//栈顶（最近添加的元素）
        private int N = 0;//元素数量

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
        }

        public Item pop()
        {
            //从栈顶删除元素
            Item item = first.item;
            first = first.next;
            N--;
            return item;
        }

        public Item peek()
        //获取栈顶元素
        { return first.item; }

        public IEnumerator<Item> GetEnumerator()
        { return new StackEnumerator(first); }

        IEnumerator IEnumerable.GetEnumerator()
        { return GetEnumerator(); }

        class StackEnumerator : IEnumerator<Item>
        {
        	//枚举器
            private Node current;
            private Node first;
          
            public StackEnumerator(Node first)
            {
                current = new Node();
                current.next = first;
                this.first = current;
            }

            public Item Current
            {
                get{ return current.item; }
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
}
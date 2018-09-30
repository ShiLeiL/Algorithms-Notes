using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.3.15 */
            MyQueue<string> readInts = new MyQueue<string>();
            Console.WriteLine("请输入要输出的字符串的倒数位置：");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入字符串组：(一行一个字符串，以输入0为结束）");
            while(true)
            {
                string temp1 = Console.ReadLine();
                if (temp1 == "0") break;
                readInts.enqueue(temp1);
            }            
            Console.WriteLine();

            int temp2 = readInts.size() - k;
            for (int i=0;i<temp2;i++)
            { readInts.dequeue(); }
            Console.WriteLine(readInts.dequeue());
            Console.ReadKey();
        }
    }

    public class MyQueue<Item> : IEnumerable<Item>
    {
        private Node first;//队头
        private Node last;//队尾
        private int N = 0;//元素数量

        private class Node
        {
            //定义了结点的嵌套类
            public Item item;
            public Node next;
        }

        public MyQueue()
        {
            first = null;
            last = null;
            N = 0;
        }

        public bool isEmpty()
        { return first == null; }

        public int size()
        { return N; }

        public Item peek()
        //获取队头元素
        { return first.item; }

        public void enqueue(Item item)
        {
            //将元素添加到队尾
            Node oldlast = last;
            last = new Node();
            last.item = item;
            last.next = null;
            if (isEmpty())
                first = last;
            else oldlast.next = last;
            N++;
        }

        public Item dequeue()
        {
            //从队头删除元素
            Item item = first.item;
            first = first.next;
            N--;
            if (isEmpty())
                last = null;
            return item;
        }

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
}
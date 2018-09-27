using System;
using System.Collections;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.3.8 */
            //猜测题目意为根据指示压入栈或弹出后，栈中的数组内容和大小
            //以下代码的打印输出为：
            //was best times of the was the it
            //最后栈中数组的内容为：it
            //大小为2
            DoublingStackOfStrings a = new DoublingStackOfStrings(5);
            string[] inP = ("it was - the best - of times - - - it was - the - -").Split(' ');
            for(int i=0;i<inP.Length;i++)
            {
                if (inP[i] != "-")
                    a.push(inP[i]);
                else if (!a.isEmpty())
                    Console.Write(a.pop() + " ");
            }
            Console.ReadKey();
        }
    }

    public class DoublingStackOfStrings : IEnumerable
    {
        private string[] a;
        private int N;

        public DoublingStackOfStrings(int capacity)
        {
            a = new string[capacity];
            N = 0;
        }

        public bool isEmpty()
        { return N == 0; }

        public int size()
        { return N; }

        private void resize(int capacity)
        { 
            //将栈移动到一个大小为capacity的新数组
            string[] temp = new string[capacity];
            for (int i = 0; i < N; i++)
                temp[i] = a[i];
            a = temp;
        }

        public void push(string item)
        {
            //将元素添加到栈顶
            if (N == a.Length)
                resize(2 * a.Length);
            a[N++] = item;
        }

        public string pop()
        {
            //从栈顶删除元素
            string temp = a[N - 1];
            a[N - 1] = null;
            N--;
            if (N > 0 && N == a.Length / 4)
                resize(a.Length / 2);
            return temp;
        }

        public string peek()
        { return a[N - 1]; }
      
        IEnumerator IEnumerable.GetEnumerator()
        { return new StackEnumerator(a); }

        class StackEnumerator : IEnumerator
        {
            //枚举器
            private string[] _a;
            private int position;

            public StackEnumerator(string[] theStack)
            {
                _a = new string[theStack.Length];
                for (int i = 0; i < theStack.Length; i++)
                    _a[i] = theStack[i];
            }

            public object Current
            {
                get { return _a[position]; }
            }
           
            bool IEnumerator.MoveNext()
            {
                if(position<_a.Length-1)
                {
                    position++;
                    return true;
                }
                return false;
            }

            void IEnumerator.Reset()
            {
                position=-1;
            }
        }
    }
}
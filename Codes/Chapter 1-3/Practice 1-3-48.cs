public class DoubleStack<T>
    {
        /* 算法（第四版） 1.3.48 */
        //Deque为1.3.33中的类
        Deque<T> a;
        private int leftCount, rightCount;

        public DoubleStack()
        { a = new Deque<T>(); }

        //判断左栈是否为空
        public bool leftIsEmpty()
        { return leftCount == 0; }

        //判断右栈是否为空
        public bool rightIsEmpty()
        { return rightCount == 0; }

        //左栈个数
        public int leftSize()
        { return leftCount; }

        //右栈个数
        public int rightSize()
        { return rightCount; }

        //向左栈添加一个元素
        public void pushLeft(T item)
        {
            a.pushLeft(item);
            leftCount++;
        }

        //向右栈添加一个元素
        public void pushRight(T item)
        {
            a.pushRight(item);
            rightCount++;
        }

        //从左栈删除一个元素
        public T popLeft()
        {
            T temp = a.popLeft();
            leftCount--;
            return temp;
        }

        //从右栈删除一个元素
        public T popRight()
        {
            T temp = a.popRight();
            rightCount--;
            return temp;
        }
    }
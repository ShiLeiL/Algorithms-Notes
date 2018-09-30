namespace AlgorithmsApplication
{
    public class Algorithms<T>
    {
        /* 算法（第四版） 1.3.19 */
        private Node first;

        class Node
        {
            public T item;
            public Node next;
        }
      
        public void deleteLast()
        {
            Node temp1 = first;//用于保存尾结点
            Node temp2 = null;//用于保存尾结点前的一个结点
            for (int i = 0;temp1.next!=null;i++)
            {
                temp2 = temp1;
                temp1 = temp1.next;
            }
            temp2.next=null;
        }
    }
}
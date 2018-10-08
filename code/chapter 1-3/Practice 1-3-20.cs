namespace AlgorithmsApplication
{
    public class Algorithms<T>
    {
        /* 算法（第四版） 1.3.20 */
        private Node first;
        private Node last;

        class Node
        {
            public T item;
            public Node next;
        }
      
        public void delete(int k)
        {
            if(k==1)
            {
                first=first.next;
                return;
            }
            Node temp = first;
            for (int i = 0;i<k-1;i++)
            { temp = temp.next;}
            temp.next = temp.next.next;
        }
    }
}
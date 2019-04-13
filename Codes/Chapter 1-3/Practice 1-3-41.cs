public Queue(Queue<T> q)
{
    /* 算法（第四版） 1.3.41 */
    while(!q.isEmpty())
        enqueue(q.dequeue());
}
public bool Judge(Queue<string> queue)
{
    /* 算法（第四版） 1.3.45 */
    //把输入序列看做是一个队列
    int count = 0;//统计当前减号的个数
    int temp = 0;//记录插入的个数
    for(int i=0;i<queue.Count;i++)
    {
        if (queue.Dequeue() == "-")
            count++;
        else
            temp = Convert.ToInt32(queue.Dequeue())+1;
        if (count > temp)
            return true;
    }
    return false;
}
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.3.39 */
    //此类型为每次的生产（或消费）产生一个新线程
    //所以生产插入队列的顺序不是按插入请求的顺序，而是按线程完成顺序插入的
    //插入队列顺序有待改进
    public class RingBuffer<T>
    {
        private static T[] a;
        private static int count = 0;
        static EventWaitHandle consumeSignal = new AutoResetEvent(false);//可消费信号
        static EventWaitHandle produceSignal = new AutoResetEvent(false);//可生产信号

        public RingBuffer(int N)
        {
            a = new T[N];
            count = 0;
        }

        public bool isEmpty()
        { return count == 0; }

        public bool isFull()
        { return count == a.Length; }

        //为消费产生新线程
        public async Task<T> consumes()
        {
            T result = await Task.Run(() => consume());
            return result;
        }

        //为生产产生新线程
        public async void produces(T temp)
        { await Task.Run(() => produce(temp)); }

        //进行消费
        private T consume()
        {
            if (count == 0)
                consumeSignal.WaitOne();//若队列中无数据，则等待可消费信号
            T temp = a[0];
            for (int i = 0; i < count - 1; i++)
                a[i] = a[i + 1];
            a[count - 1] = default(T);
            count--;
            produceSignal.Set();//发送可生产信号
            return temp;
        }

        //进行生产
        private void produce(T temp)
        {
            if (count >= a.Length)
                produceSignal.WaitOne();//若队列已满，则等待可生产信号
            a[count++] = temp;
            consumeSignal.Set();//发送可消费信号
        }
    }
}
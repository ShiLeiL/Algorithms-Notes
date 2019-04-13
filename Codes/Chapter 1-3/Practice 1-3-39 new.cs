using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsApplication
{
    /* 算法（第四版） 1.3.39 new */
    //此为更改后的类型
    //于原写法不同的是
    //生产改为单独的一条线程，该线程在初始化类型时就开始启动，等待生产信号再进行生产
    //每次请求生产就传入数据并发送生产信号
    //因为生产并不在主线程上，为了防止生产时，因主线程速度较快而改变传入参数
    //所以每次生产将会把主线程挂起1ms
    //感觉还能再优化
    public class RingBuffer<T>
    {
        private static T[] a;
        private static int count = 0;
        static EventWaitHandle consumeSignal = new AutoResetEvent(false);//可消费信号
        static EventWaitHandle produceSignal = new AutoResetEvent(false);//可生产信号
        static EventWaitHandle produceSignal2 = new AutoResetEvent(false);//生产信号
        static ThreadStart pro = new ThreadStart(produce);
        Thread produceThread = new Thread(pro);//生产线程
        static T date;

        public RingBuffer(int N)
        {
            produceThread.Start();
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

        //生产请求
        public void produces(T x)
        {
            date = x;
            produceSignal2.Set();
            Thread.Sleep(1);
        }

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
        private static void produce()
        {
            while (true)
            {
                produceSignal2.WaitOne();
                if (count >= a.Length)
                    produceSignal.WaitOne();//若队列已满，则等待可生产信号
                a[count++] = date;
                consumeSignal.Set();//发送可生产信号
            }
        }
    }
}
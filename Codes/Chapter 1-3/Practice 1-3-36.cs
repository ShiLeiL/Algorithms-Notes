class RandomQueueEnumerator : IEnumerator<T>
{
    /* 算法（第四版） 1.3.36 */
    //与1.3.34中的迭代器一致
    private T[] _a;
    private int position = -1;
    private string temp = "";//已输出的随机数临时容器
    private Random rd = new Random();
    private int num;//用于存放当前随机数
    private int N;

    public RandomQueueEnumerator(T[] theRandomBag, int theN)
    {
        _a = new T[theRandomBag.Length];
        for (int i = 0; i < theRandomBag.Length; i++)
            _a[i] = theRandomBag[i];
        N = theN;
    }

    public T Current => _a[num];
    object IEnumerator.Current => _a[num];

    void IDisposable.Dispose()
    {
        _a = default(T[]);
        position = -1;
    }

    bool IEnumerator.MoveNext()
    {
        while (position < N)
        {
            num = rd.Next(N);
            if (temp.IndexOf(num.ToString()) >= 0)
                continue;
            else
            {
                temp += num.ToString();
                position++;
                return true;
            }
        }
        return false;
    }

    void IEnumerator.Reset()
    {
        position = -1;
        temp = "";
    }
}
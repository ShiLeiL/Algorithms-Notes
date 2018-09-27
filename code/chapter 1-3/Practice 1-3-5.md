java代码转换成C#如下：<br>
<br>
static void Main(string[] args)<br>
{<br>
　　/* 算法（第四版） 1.3.4 */<br>
　　int N = Convert.ToInt32(Console.ReadLine());<br>
　　Stack<int> stack = new Stack<int>();<br>
　　while(N>0)<br>
　　{<br>
　　　　stack.push(N % 2);<br>
　　　　N = N / 2;<br>
　　}<br>
　　Console.WriteLine();<br>
　　foreach(int d in stack)<br>
　　　　Console.Write(d);<br>
　　Console.ReadKey();<br>
}<br>
<br>
//上面的程序是通过利用栈打印N的二进制表示<br>
//根据代码可以知道，我们求二级制表示先得到的是右边第一位，但打印是从左至右的<br>
//所以我们利用栈先进后出的特点，把先得到的结果压入栈，让其最后打印，从而得到正确结果
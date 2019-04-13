java代码转换成C#如下：<br>
<br>
public static string mystery(string s)<br>
{<br>
　　int N = s.Length;<br>
　　if (N <= 1) return s;<br>
　　string a = s.Substring(0, N / 2);<br>
　　string b = s.Substring(N / 2);<br>
　　return mystery(b) + mystery(a);<br>
}<br>
<br>
//上面的程序表示把s对半分一直分到长度为1为止后字符翻转<br>
//所以+最后输出为字符串s的字符翻转<br>
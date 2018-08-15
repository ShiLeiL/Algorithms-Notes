public static String exR2(int n)  <br>
{  <br>
    String s = exR2(n - 3) +  n + exR2(n - 2) + n;  <br>
    if (n <= 0) return "";  <br>
    return s;  <br>
}<br>

因条件语句（if语句）在递归之后，无法限制到递归语句使其跳出递归。从而导致程序会陷入无限递归，直到堆栈溢出。<br>
即，假设给定参数n为3。语句会在exR2（n-3）处开始递归成exR2（0），之后再递归成exR2（-3）、exR2（-6）、exR2（-9）而陷入无限递归。
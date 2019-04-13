using System;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        static void Main(string[] args)
        {
            /* 算法（第四版） 1.2.6 */
            string s = "ACTGACG";
            string t = "TGACGAC";
            string test = t + t;
            if (test.IndexOf(s)!= -1 && s.Length==t.Length) Console.WriteLine("yes");
            else Console.WriteLine("no");
            Console.ReadKey();
        }
    }
}
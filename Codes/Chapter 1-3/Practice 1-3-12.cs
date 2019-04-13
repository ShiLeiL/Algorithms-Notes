using System.Collections.Generic;

namespace AlgorithmsApplication
{
    class Algorithms
    {
        public static Stack<string> Copy(Stack<string> a)
        {
            /* 算法（第四版） 1.3.12 */
            Stack<string> copy = new Stack<string>();
            foreach (string i in a)
                copy.Push(i);
            return copy;
        }
    }
}
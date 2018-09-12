public static int[] readInts(string name)
{
    /* 算法（第四版） 1.2.15 */
    In in = new In(name);
    string input = Console.ReadLine();
    string[] words = Regex.Split(input, "\\s+", RegexOptions.IgnoreCase);
    int[] ints = new int[words.Length];
    for (int i = 0; i < words.Length; i++)
        ints[i]= Convert.ToInt32(words[i]);
    return ints;
}
using System.Collections.Generic;
internal static class Program
{
    private static void Main(string[] args)
    {
        var x = Console.ReadLine()!.ToCharArray().ToList();
        //var x = "12".ToCharArray().ToList();
        int countChars = x.Count();
        int countUnique = CountUnique(x) - 1;
        int multiply = MultiplyUnique(countChars, countUnique);
        int comboCount = Factorial(countChars) / multiply;
        List<int> output = new List<int>();
        output.Add(int.Parse(new string(x.ToArray())));

        while (output.ToArray().Length < comboCount)
        {
            char[] num = new char[countChars];
            List<char> x1 = new List<char>().Concat(x).ToList();


            for (int i = 0; i < num.Count(); i++)
            {
                int ran;
                if (x1.Count != 0)
                {
                    ran = new Random().Next(0, x1.Count);
                }
                else
                {
                    ran = 0;
                }
                num[i] = x1[ran];

                x1.RemoveAt(ran);
            }

            if (!output.Contains(int.Parse(new string(num))))
            {
                output.Add(int.Parse(new string(num)));
            }

        }



        output.ForEach(x => System.Console.WriteLine(x));
    }

    static int Factorial(int n)
    {
        if (n == 1) return 1;

        return n * Factorial(n - 1);
    }
    static int MultiplyUnique(int n, int m)
    {
        int res = 1;
        for (int i = 1; i < n - m + 1; i++)
        {
            res *= i;
        }

        return res;
    }
    static int CountGenerates(int n, int m)
    {
        return Factorial(n) / MultiplyUnique(n, m);
    }
    static int CountUnique(List<Char> ch)
    {
        List<char> ch2 = new List<char>();

        for (int i = 0; i < ch.Count; i++)
        {
            if (!ch2.Contains(ch[i]))
            {
                ch2.Add(ch[i]);
            }
        }

        return ch2.Count;
    }
}
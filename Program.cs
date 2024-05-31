using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Text? Insert here: ");
        FancyPrint(Console.ReadLine() ?? "");
    }
    static void FancyPrint(string Text)
    {
        string Storage = "";
        List<string> Index = new();
        List<int> Case = new();
        foreach (char i in Text)
        {
            if (char.IsLetter(i) || char.IsDigit(i))
            {
                Index.Add((Convert.ToInt32(i.ToString().ToUpper().ToCharArray()[0])).ToString());
                if (char.IsUpper(i))
                {
                    Case.Add(1);
                }
                else
                {
                    Case.Add(0);
                }
            }
            else if (i == ' ')
            {
                Index.Add("-1");
                Case.Add(0);
            }
            else
            {
                Index.Add(i.ToString());
                Case.Add(0);
            }
        }
        int index = 0;
        foreach (string i in Index)
        {
            try
            {
                int I = int.Parse(i);
                for (int x = I > 64 ? 65 : 48; x < I + 1; x++)
                {
                    if (I != 0)
                    {
                        Console.WriteLine("{0}{1}", Storage, Case[index] == 0 ? ((char)x).ToString().ToLower() : (char)x);
                        if (x == I)
                        {
                            Storage += Case[index] == 0 ? ((char)x).ToString().ToLower() : (char)x;
                        }
                    }
                }
                if (I == -1)
                {
                    Console.WriteLine("{0} ", Storage);
                    Storage += " ";
                }
            }
            catch
            {
                Console.WriteLine("{0}{1}", Storage, i);
                Storage += i;
            }
            finally
            {
                index++;
            }
        }
        Console.Read();
    }
}

using System;

class MainClass
{

    public static string FirstReverse(string str)
    {

        if (str.Length == 1)
            return str;

        return str[str.Length - 1] + FirstReverse(str.Substring(0, str.Length - 1));

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(FirstReverse(Console.ReadLine()));
    }

}
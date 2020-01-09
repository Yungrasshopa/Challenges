//Have the function AlphabetSoup(str) take the str string
//parameter being passed and return the string with 
//the letters in alphabetical order(ie.hello becomes
//ehllo). Assume numbers and punctuation symbols
//will not be included in the string.

using System;

class MainClass
{

    public static string AlphabetSoup(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Sort<char>(chars);
        return new string(chars);
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(AlphabetSoup(Console.ReadLine()));
    }

}
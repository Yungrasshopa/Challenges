//Have the function LetterChanges(str) take the str parameter
//being passed and modify it using the following algorithm.Replace 
//every letter in the string with the letter following it in the alphabet 
//(ie.c becomes d, z becomes a). Then capitalize every vowel in this new 
//string (a, e, i, o, u) and finally return this modified string.

using System;

class MainClass
{
    public static char CapitalizeIfVowel(char letter)
    {
        char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

        if (Array.Exists<char>(vowels, vowel => vowel == letter))
            return letter.ToString().ToUpper().ToCharArray()[0];

        return letter;

    }
    public static char IncrementLetter(char letter)
    {
        if (((int)letter < 'a' || (int)letter > 'z') && ((int)letter < 'A' || (int)letter > 'Z'))
            return letter;

        int incrementedLetterValue = ((int)letter + 1 - 'a') % 26 + 'a';

        return (char)incrementedLetterValue;
    }

    public static string LetterChanges(string str)
    {

        string modifiedString = "";

        foreach(char letter in str.ToCharArray())
        {
            char incrementedLetter = IncrementLetter(letter);
            incrementedLetter = CapitalizeIfVowel(incrementedLetter);

            modifiedString =  modifiedString + incrementedLetter;
        }

        return modifiedString;

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(LetterChanges(Console.ReadLine()));
    }

}
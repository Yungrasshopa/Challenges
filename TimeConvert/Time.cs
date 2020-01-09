//Have the function TimeConvert(num) take the num 
//parameter being passed and return the number 
//of hours and minutes the parameter converts 
//to(ie. if num = 63 then the output should be 1:3).
//Separate the number of hours and minutes with a colon.

using System;

class MainClass
{

    public static string TimeConvert(int num)
    {
        //return (num % 60).ToString() + (num - (num % 60) * 60).ToString();
        return (num / 60).ToString() + ":" + (num % 60).ToString();
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(TimeConvert(Convert.ToInt32(Console.ReadLine())));
    }

}
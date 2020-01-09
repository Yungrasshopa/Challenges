//Have the function CorrectPath(str) read the str parameter 
//being passed, which will represent the movements made 
//in a 5x5 grid of cells starting from the top left position.
//The characters in the input string will be entirely composed
//of: r, l, u, d, ?. Each of the characters stand for the 
//direction to take within the grid, for example: r = right, 
//l = left, u = up, d = down.Your goal is to determine what 
//characters the question marks should be in order for a path 
//to be created to go from the top left of the grid all the way 
//to the bottom right without touching previously travelled on 
//cells in the grid.

//For example: if str is "r?d?drdd" then your program should output 
//the final correct string that will allow a path to be formed from 
//the top left of a 5x5 grid to the bottom right. For this input, your 
//program should therefore return the string rrdrdrdd. There will only 
//ever be one correct path and there will always be at least one 
//question mark within the input string.

using System;
using System.Collections.Generic;
using System.Text;

public class Point
{
    public int x;
    public int y;



    public Point(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

}

public class Player
{
    public static int Dim = 5;

    public Point position = new Point(0, Dim - 1);

    public bool ValidDirections(string directions, Point pos)
    {

        List<Point> previousPositions = new List<Point>();

        previousPositions.Add(new Point(pos.x, pos.y));

        foreach (char dir in directions)
        {
            switch (dir)
            {
                case 'r':
                    ++pos.x;
                    break;
                case 'l':
                    --pos.x;
                    break;
                case 'u':
                    ++pos.y;
                    break;
                case 'd':
                    --pos.y;
                    break;
                case '?':
                    return false;
                default:
                    break;
            }
            for (int i = 0; i < previousPositions.Count; ++i)
            {
                Point p = previousPositions[i];
                if (p.x == pos.x && p.y == pos.y)
                {
                    return false;
                }
            }
            previousPositions.Add(new Point(pos.x, pos.y));
        }

        return true;

    }
    public char[] Advance(string directions, int index, Point pos)
    {
        if (index == directions.Length)
            return directions.ToCharArray();

        switch (directions[index])
        {
            case 'r':
                ++pos.x;
                break;
            case 'l':
                --pos.x;
                break;
            case 'u':
                ++pos.y;
                break;
            case 'd':
                --pos.y;
                break;
            case '?':
                StringBuilder right = new StringBuilder(directions);
                right[index] = 'r';
                char[] d = Advance(right.ToString(), index, new Point(pos.x, pos.y));
                if (!Array.Exists(d, c => c == 'c') &&
                    ValidDirections(right.ToString(), new Point(0, 0)))
                    return Advance(new string(d), 12, pos);

                StringBuilder left = new StringBuilder(directions);
                left[index] = 'l';
                d = Advance(left.ToString(), index, new Point(pos.x, pos.y));
                if (!Array.Exists(d, c => c == 'c') &&
                    ValidDirections(left.ToString(), new Point(0, 0)))
                    return Advance(new string(d), 12, pos);

                StringBuilder up = new StringBuilder(directions);
                up[index] = 'u';
                d = Advance(up.ToString(), index, new Point(pos.x, pos.y));
                if (!Array.Exists(d, c => c == 'c') &&
                    ValidDirections(up.ToString(), new Point(0, 0)))
                    return d;

                StringBuilder down = new StringBuilder(directions);
                down[index] = 'd';
                d = Advance(down.ToString(), index, new Point(pos.x, pos.y));
                if (!Array.Exists(d, c => c == 'c') &&
                    ValidDirections(down.ToString(), new Point(0, 0)))
                    return d;

                break;
            default:
                break;
        }

        if (pos.x > Dim - 1 || pos.x < 0 ||
            pos.y > Dim - 1 || pos.y < 0)
        {
            StringBuilder dir = new StringBuilder(directions);
            char a = directions[index];
            dir[index] = 'c';
            return dir.ToString().ToCharArray();
        }


        return Advance(directions, index + 1, pos);
    }

}

class MainClass
{
    public static string CorrectPath(string str)
    {
        List<char> correctPath = new List<char>();
        Player John = new Player();

            var s = new string(John.Advance(str, 0, John.position));
        return s;
    }

    static void Main()
    {
        // keep this function call here
        //Console.WriteLine(CorrectPath(Console.ReadLine()));
        Console.WriteLine(CorrectPath("drdr??rrddd?"));
    }

}
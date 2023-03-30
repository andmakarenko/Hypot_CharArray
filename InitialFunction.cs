using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//this file contains the initial idea implemented in one function:
//drawing a straight or a diagonal line from one point to another on a 2D char array
//this algorithm can be used to define whether an enemy is visible for our character on a 2D map
class First
{
    static void FindHypot(char[,] map, (int, int) first, (int, int) second)
    {
        int deltaX = second.Item2 - first.Item2;
        int deltaY = second.Item1 - first.Item1;

        char testChar = map[first.Item1, first.Item2];

        if (deltaX == 0 && deltaY == 0)
        {
            map[first.Item1, first.Item2] = '#';
            return;
        }
        else if (deltaX == 0)
        {
            while (testChar != '@')
            {
                first.Item1 += Math.Sign(deltaY);
                testChar = map[first.Item1, first.Item2];
                map[first.Item1, first.Item2] = '#';
            }
        }
        else if (deltaY == 0)
        {
            while (testChar != '@')
            {
                first.Item2 += Math.Sign(deltaX);
                testChar = map[first.Item1, first.Item2];
                map[first.Item1, first.Item2] = '#';
            }
        }

        if (deltaY < 0 && deltaX < 0)
        {
            while (testChar != '@')
            {
                first.Item1 -= 1;
                first.Item2 -= (int)Math.Round((double)deltaX / deltaY, 0);
                testChar = map[first.Item1, first.Item2];
                map[first.Item1, first.Item2] = '#';
                deltaY = second.Item1 - first.Item1;
                deltaX = second.Item2 - first.Item2;
            }
        }
        else if (deltaY > 0 && deltaX > 0)
        {
            while (testChar != '@')
            {
                first.Item1 += 1;
                first.Item2 += (int)Math.Round((double)deltaX / deltaY, 0);
                testChar = map[first.Item1, first.Item2];
                map[first.Item1, first.Item2] = '#';
                deltaY = second.Item1 - first.Item1;
                deltaX = second.Item2 - first.Item2;
            }
        }
        else if (deltaY < 0 && deltaX > 0)
        {
            while (testChar != '@')
            {
                first.Item1 += (int)Math.Round((double)deltaY / deltaX, 0);
                first.Item2 -= (int)Math.Round((double)deltaX / deltaY, 0);
                testChar = map[first.Item1, first.Item2];
                map[first.Item1, first.Item2] = '#';
                deltaY = second.Item1 - first.Item1;
                deltaX = second.Item2 - first.Item2;
            }
        }
        else if (deltaY > 0 && deltaX < 0)
        {
            while (testChar != '@')
            {
                first.Item1 += 1;
                first.Item2 += (int)Math.Round((double)deltaX / deltaY, 0);
                testChar = map[first.Item1, first.Item2];
                map[first.Item1, first.Item2] = '#';
                deltaY = second.Item1 - first.Item1;
                deltaX = second.Item2 - first.Item2;
            }
        }
    }
}

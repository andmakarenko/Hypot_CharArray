using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//concrete strategies that implement the algorithms from the initial function
class DxDyEqualZero : IStrategy
{ 
    public void Execute(char[,] map, (int, int) first, (int, int) second)
    {
        map[first.Item1, first.Item2] = '#';
        return;
    }
}

class DxEqualsZero : IStrategy
{
    public void Execute(char[,] map, (int, int) first, (int, int) second)
    {
        char testChar = map[first.Item1, first.Item2];
        int deltaY = second.Item1 - first.Item1;

        while (testChar != '@')
        {
            first.Item1 += Math.Sign(deltaY);
            testChar = map[first.Item1, first.Item2];
            map[first.Item1, first.Item2] = '#';
        }
    }
}

class DyEqualsZero : IStrategy
{
    public void Execute(char[,] map, (int, int) first, (int, int) second)
    {
        char testChar = map[first.Item1, first.Item2];
        int deltaX = second.Item2 - first.Item2;

        while (testChar != '@')
        {
            first.Item2 += Math.Sign(deltaX);
            testChar = map[first.Item1, first.Item2];
            map[first.Item1, first.Item2] = '#';
        }
    }
}

class DyLessDxLess : IStrategy
{
    public void Execute(char[,] map, (int, int) first, (int, int) second)
    {
        int deltaX = second.Item2 - first.Item2;
        int deltaY = second.Item1 - first.Item1;

        char testChar = map[first.Item1, first.Item2];

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
}

class DyGreaterDxGreater : IStrategy
{
    public void Execute(char[,] map, (int, int) first, (int, int) second)
    {
        int deltaX = second.Item2 - first.Item2;
        int deltaY = second.Item1 - first.Item1;

        char testChar = map[first.Item1, first.Item2];

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

class DyLessDxGreater : IStrategy
{
    public void Execute(char[,] map, (int, int) first, (int, int) second)
    {
        int deltaX = second.Item2 - first.Item2;
        int deltaY = second.Item1 - first.Item1;

        char testChar = map[first.Item1, first.Item2];

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
}

class DyGreaterDxLess : IStrategy
{
    public void Execute(char[,] map, (int, int) first, (int, int) second)
    {
        int deltaX = second.Item2 - first.Item2;
        int deltaY = second.Item1 - first.Item1;

        char testChar = map[first.Item1, first.Item2];

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



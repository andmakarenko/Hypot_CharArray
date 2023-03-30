using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hypot_CharArray
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char[,] map = new char[,]
            {
                {'$', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '@', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}
            };

            var first = (0, 0);
            var second = (7, 7);

            ShowMap(map);
            FindHypot(map, first, second);
            Console.WriteLine();
            ShowMap(map);
            Console.Read();

        }

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

        static void ShowMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
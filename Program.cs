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
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '@', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '$', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'}
            };

            ShowMap(map);
            FindHypot(map);
            ShowMap(map);
            Console.Read();

        }

        static void FindHypot(char[,] map)
        {
            var first = (7, 7);
            var second = (1, 2);

            int deltaX = first.Item1 - second.Item1;
            int deltaY = first.Item2 - second.Item2;

            char testChar = map[first.Item1, first.Item2];

            if (deltaY < 0)
            {
                while (testChar != '@')
                {
                    first.Item1++;
                    first.Item2 += (int)Math.Round((double)deltaY / deltaX, 0);
                    testChar = map[first.Item1, first.Item2];
                    map[first.Item1, first.Item2] = '#';
                    deltaX = first.Item1 - second.Item1;
                    deltaY = first.Item2 - second.Item2;
                }
            }
            else if (deltaY > 0)
            {
                while (testChar != '@')
                {
                    first.Item1--;
                    first.Item2 -= (int)Math.Round((double)deltaY / deltaX, 0);
                    testChar = map[first.Item1, first.Item2];
                    map[first.Item1, first.Item2] = '#';
                    deltaX = first.Item1 - second.Item1;
                    deltaY = first.Item2 - second.Item2;
                }
            }
            else
            { 
            }
        }
        
        static void ShowMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}

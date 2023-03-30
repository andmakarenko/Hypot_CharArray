using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//strategy interface
interface IStrategy
{
    void Execute(char[,] map, (int, int) first, (int, int) second);
}


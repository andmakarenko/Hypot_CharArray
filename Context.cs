using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//the context which swithces to the required algorithm and executes it
class Context
{
    private IStrategy algorithm;
    char[,] map;
    (int, int) first;
    (int, int) second;


    public Context(char[,] map, (int, int) first, (int, int) second)
    {   
        this.map = map;
        this.first = first;
        this.second = second;

        int deltaX = second.Item2 - first.Item2;
        int deltaY = second.Item1 - first.Item1;

        //the type of the algorithm that will be used depends on dX and dY values
        if (deltaX == 0 && deltaY == 0)
        {
            algorithm = new DxDyEqualZero();
        }
        else if (deltaX == 0)
        {
            algorithm = new DxEqualsZero();
        }
        else if (deltaY == 0)
        {
            algorithm = new DyEqualsZero();
        }
        else if (deltaY < 0 && deltaX < 0)
        {
            algorithm = new DyLessDxLess();
        }
        else if (deltaY > 0 && deltaX > 0)
        {
            algorithm = new DyGreaterDxGreater();
        }
        else if (deltaY < 0 && deltaX > 0)
        {
            algorithm = new DyLessDxGreater();
        }
        else if (deltaY > 0 && deltaX < 0)
        {
            algorithm = new DyGreaterDxLess();
        }
    }

    //the method which calls Execute from its "algorithm" field, that contains the required algorithm
    public void GetHypot()
    {
        algorithm.Execute(map, first, second);
    }
}
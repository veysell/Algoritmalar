using System;

namespace StationProblem
{
 
    class Program
    {
        static int[,] cost = {
                { 0,10,75,94},
                { -1,0,35,50},
                { -1,-1,0,80},
                { -1,-1,-1,0}
        };
        
        static int FindStationCost(int start, int finish,int counter=-1) // counter is a optional variable
        {
            if (start > finish) return -1;
            if (start == finish|| start +1==finish) return cost[start, finish];
            int min = cost[start, finish];
            if (finish != counter - 1) {
                
                int value = FindStationCost(start, counter + 1,counter+1) + FindStationCost(counter + 1, finish,counter + 1);
                if (value < min) min = value;
            }
            return min;
        }

        static int StationCost(int start, int finish)
        {
            int temp = start;
            return FindStationCost(start, finish, temp);
        }

        static void Main(string[] args)
        {
             Console.WriteLine(StationCost(0, 3));
            
        
        }

    }
    
}

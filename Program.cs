using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBetaTester
{
    class Program
    {
        static int searchDepth = 4;
        static void Main(string[] args)
        {
            alphaBeta(4, -2000000, 2000000, new int[] { 0, 0 }, -1);
        }

        static int getNum(bool isChildNodes)
        {
            string s = isChildNodes ? "Enter the number of child nodes: " : "Enter the value of the root node: ";
            Console.WriteLine(s);
            return Convert.ToInt32(Console.ReadLine());
        }

        static int[][] alphaBeta(int depth, int alpha, int beta, int[] move, int player)
        {
            player *= -1;
            if (depth == 0) return new int[][] { move, new int[] { /*player */ getNum(false) } };
            Console.WriteLine("At level: " + (4 - depth) + " (alpha: " + alpha + ", beta: " + beta + ", " + ((player == 1) ? "white" : "black") + "'s move, " + "player = " + player + ")");
            int numMoves = getNum(true);
            //TODO: sort for alphabeta
            for (int i = 0; i < numMoves; i++) { 
                    int[][] retVal = alphaBeta(depth - 1, alpha, beta, new int[] { i, 0 }, player);
                    if (player == -1)
                    {
                        if (retVal[1][0] <= beta)
                        {
                            beta = retVal[1][0];
                            Console.WriteLine("Because player is " + player + " at level: " + (4 - depth) + ", new beta value is: " + beta);
                            if (depth == searchDepth) move = retVal[0];
                        }
                    }
                    else
                    {
                        if (retVal[1][0] > alpha)
                        {
                            alpha = retVal[1][0];
                            Console.WriteLine("Because player is " + player + " at level: " + (4 - depth) + ", new alpha value: " + alpha);
                            if (depth == searchDepth) move = retVal[0];
                        }
                    }
                    if (alpha >= beta)
                    {
                    Console.WriteLine("Pruning branch at level: " + (4 - depth));
                        if (player == -1) return new int[][] { move, new int[] { beta } };
                        else return new int[][] { move, new int[] { alpha } };
                    }
                }
            if (player == -1) return new int[][] { move, new int[] { beta } };
            else return new int[][] { move, new int[] { alpha } };
        }
    }
}

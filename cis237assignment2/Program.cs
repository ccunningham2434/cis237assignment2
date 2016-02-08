/**
 * Author: Chad Cunningham (Well David Barnes started it and I finished it)
 * CIS 237
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the _maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first _maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '.' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            // >This maze has no exit. Used to test backtracking.
            //{ { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            //{ '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            //{ '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            //{ '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            //{ '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '#' },
            //{ '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            //{ '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            //{ '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            //{ '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            //{ '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            //{ '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            //{ '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            //Create the second _maze by transposing the first _maze
            char[,] maze2 = transposeMaze(maze1);

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            /// <summary>
            /// Tell the instance to solve the first _maze with the passed _maze, and start coordinates.
            /// </summary>
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            //Solve the transposed _maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);
        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array _maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            // >Create a temporary 2d array and make its lengths the 'switched' lengths of the parameter array.
            char[,] transposedMaze = new char[mazeToTranspose.GetLength(1), mazeToTranspose.GetLength(0)];

            for (int y = 0; y < mazeToTranspose.GetLength(1); y++)
            {
                for (int x = 0; x < mazeToTranspose.GetLength(0); x++)
                {
                    transposedMaze[x, y] = mazeToTranspose[y, x];
                }
            }
            return transposedMaze;
        }

    }


}

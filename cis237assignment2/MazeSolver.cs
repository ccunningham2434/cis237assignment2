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
    /// <summary>
    /// This class is used for solving a char array _maze.
    /// You might want to add other methods to help you out.
    /// A print _maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] _maze;
        int _xStart;
        int _yStart;

        bool _mazeSolved;

        /// <summary>
        /// Default Constuctor to setup a new _maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the _maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new _maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class.
            //It is possible that you will not need these class level ones and can get all of the work done
            //with the local ones. Regardless of how you implement it, here are the class level assignments.
            //Feel free to remove the class level variables and assignments if you determine that you don't need them.
            this._maze = maze;
            this._xStart = xStart;
            this._yStart = yStart;

            //Do work needed to use mazeTraversal recursive call and solve the _maze.
            _mazeSolved = false;
            mazeTraversal(-1, -1, _xStart, _yStart);
            Console.WriteLine("The Maze has been solved!");
            Console.WriteLine("*************************");
            Console.ReadLine();
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the _maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(int lastX, int lastY, int currentX, int currentY)
        {
            // >Display the maze.
            PrintMaze();
            // >Wait for user.
            Console.ReadLine();


            // >Try moving 'up'.(Actually moves down because of how th array was created.)
            // >Skip if the maze has been solved.
            if (_mazeSolved == false)
            {
                // >Make sure we can't move out of the array range.
                if (currentY + 1 <= _maze.GetLength(1) - 1)
                {
                    // >Skip if trying to move into a wall and if trying to move to the position we just came from.
                    if (_maze[currentX, currentY + 1] != '#' && currentY + 1 != lastY)
                    {
                        // >Mark that we 'walked' there.
                        _maze[currentX, currentY] = 'X';
                        // >Move to the new spot.
                        mazeTraversal(currentX, currentY, currentX, currentY + 1);
                    }
                }
                else// >If where we are trying to move is out of range, then the maze has been solved.
                {
                    // >Mark that we 'walked' there.
                    _maze[currentX, currentY] = 'X';
                    // >Mark the maze as solved.
                    _mazeSolved = true;
                    // >Display the maze.
                    PrintMaze();
                }
            }

            // >Try moving 'right'.
            // >Skip if the maze has been solved.
            if (_mazeSolved == false)
            {
                // >Make sure we can't move out of the array range.
                if (currentX + 1 <= _maze.GetLength(0) - 1)
                {
                    // >Skip if trying to move into a wall and if trying to move to the position we just came from.
                    if (_maze[currentX + 1, currentY] != '#' && currentX + 1 != lastX)
                    {
                        // >Mark that we 'walked' there.
                        _maze[currentX, currentY] = 'X';
                        // >Move to the new spot.
                        mazeTraversal(currentX, currentY, currentX + 1, currentY);
                    }
                }
                else// >If where we are trying to move is out of range, then the maze has been solved.
                {
                    // >Mark that we 'walked' there.
                    _maze[currentX, currentY] = 'X';
                    // >Mark the maze as solved.
                    _mazeSolved = true;
                }
            }

            // >Try moving 'down'.(Actually moves up because of how th array was created.)
            // >Skip if the maze has been solved.
            if (_mazeSolved == false)
            {
                // >Make sure we can't move out of the array range.
                if (currentY - 1 >= 0)
                {
                    // >Skip if trying to move into a wall and if trying to move to the position we just came from.
                    if (_maze[currentX, currentY - 1] != '#' && currentY - 1 != lastY)
                    {
                        // >Mark that we 'walked' there.
                        _maze[currentX, currentY] = 'X';
                        // >Move to the new spot.
                        mazeTraversal(currentX, currentY, currentX, currentY - 1);
                    }
                }
                else// >If where we are trying to move is out of range, then the maze has been solved.
                {
                    // >Mark that we 'walked' there.
                    _maze[currentX, currentY] = 'X';
                    // >Mark the maze as solved.
                    _mazeSolved = true;
                }
            }

            // >Try moving 'left'.
            // >Skip if the maze has been solved.
            if (_mazeSolved == false)
            {
                // >Make sure we can't move out of the array range.
                if (currentX - 1 >= 0)
                {
                    // >Skip if trying to move into a wall and if trying to move to the position we just came from.
                    if (_maze[currentX - 1, currentY] != '#' && currentX - 1 != lastX)
                    {
                        // >Mark that we 'walked' there.
                        _maze[currentX, currentY] = 'X';
                        // >Move to the new spot.
                        mazeTraversal(currentX, currentY, currentX - 1, currentY);
                    }
                }
                else// >If where we are trying to move is out of range, then the maze has been solved.
                {
                    // >Mark that we 'walked' there.
                    _maze[currentX, currentY] = 'X';
                    // >Mark the maze as solved.
                    _mazeSolved = true;
                }
            }

            // >Skip if the maze has been solved.
            if (_mazeSolved == false)
            {
                // >If 3 directions are blocked and 1 direction is where we just came from...
                // >    ...then mark the path as 'walked on but not the right way'.
                _maze[currentX, currentY] = '0';
                // >Display the maze.
                PrintMaze();
                // >Wait for user.
                Console.ReadLine();
            }
            // >Method will return 'to our previous step'.
        }

        // >Write the maze to the console.
        void PrintMaze()
        {
            for (int y = 0; y < _maze.GetLength(1); y++ )
            {
                for (int x=0; x < _maze.GetLength(0); x++)
                {
                    Console.Write(_maze[x, y]);
                    //Console.Write(_maze[y, x]);
                }
                // >After all x positions have been written move down a line.
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

namespace RollaBall
{
    public class MazeGeneratorCell
    {
        public int X;
        public int Y;

        public bool WallLeft=true;
        public bool WallBottom=true;
        public bool Floor=true;
        public bool Exit = false;
        public bool Key = false;

        public bool Visited=false;
        public int DistanceFromStart;
    }

    public class MazeController
    {
        public MazeGeneratorCell[,] GenerateMaze(int Xscale, int Yscale )
        {
            MazeGeneratorCell[,] maze = new MazeGeneratorCell[Xscale, Yscale];
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    maze[x, y] = new MazeGeneratorCell() {X = x, Y = y};
                }
            }

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                maze[x, Yscale - 1].WallLeft = false;
                maze[x, Yscale - 1].Floor = false;
            }

            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[Xscale - 1, y].WallBottom = false;
                maze[Xscale - 1, y].Floor = false;
            }

            RemoveWallsWithBackTracker(maze, Xscale, Yscale);
            MazeExit(maze, Xscale, Yscale);
            MazeKey(maze,Xscale,Yscale);
            MazeKey(maze,Xscale,Yscale);
            return maze;
        }

        private void RemoveWallsWithBackTracker(MazeGeneratorCell[,] maze, int xScale, int yScale)
        {
            MazeGeneratorCell current = maze[0, 0];
            current.Visited = true;
            current.DistanceFromStart = 0;
            Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
            do
            {
                List<MazeGeneratorCell> unvisitideNeighbours = new List<MazeGeneratorCell>();

                int x = current.X;
                int y = current.Y;

                if (x > 0 && !maze[x - 1, y].Visited) unvisitideNeighbours.Add(maze[x - 1, y]);
                if (y > 0 && !maze[x, y - 1].Visited) unvisitideNeighbours.Add(maze[x, y - 1]);
                if (x < xScale - 2 && !maze[x + 1, y].Visited) unvisitideNeighbours.Add(maze[x + 1, y]);
                if (y < yScale - 2 && !maze[x, y + 1].Visited) unvisitideNeighbours.Add(maze[x, y + 1]);

                if (unvisitideNeighbours.Count > 0)
                {
                    MazeGeneratorCell chosen = unvisitideNeighbours[Random.Range(0, unvisitideNeighbours.Count)];
                    RemoveWall(current, chosen);
                    chosen.Visited = true;
                    stack.Push(chosen);
                    current = chosen;
                    chosen.DistanceFromStart = stack.Count;
                }
                else
                {
                    current = stack.Pop();
                }
            } while (stack.Count > 0);
        }

        private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
        {
            if (a.X == b.X)
            {
                if (a.Y > b.Y) a.WallBottom = false;
                else b.WallBottom = false;
            }
            else
            {
                if (a.X > b.X) a.WallLeft = false;
                else b.WallLeft = false;
            }
        }

        public void MazeExit(MazeGeneratorCell[,] maze, int xScale, int yScale)
        {
            MazeGeneratorCell furthest = maze[0, 0];

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                if (maze[x, yScale - 2].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, yScale - 2];
                if (maze[x, 0].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, 0];
            }

            for (int y = 0; y < maze.GetLength(0); y++)
            {
                if (maze[xScale - 2, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[xScale - 2, y];
                if (maze[0, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[0, y];
            }

            furthest.Exit = true;
        }

        public void MazeKey(MazeGeneratorCell[,] maze, int xScale, int yScale)
        {
            MazeGeneratorCell furthest = maze[Random.Range(0,xScale-2),Random.Range(0,yScale-2)];
            
            furthest.Key = true;
        }
}
}
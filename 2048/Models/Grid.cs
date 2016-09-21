using _2048.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2048.Models
{
    internal class GameGrid
    {

        public static int MinWidth = 2;
        public static int MinHeight = 2;
        public static int MaxWidth = 10;
        public static int MaxHeight = 10;
        public int Score { get; private set; }
        private static Random rnd = new Random();
        private int height;
        private int[] newvalues = new int[] { 2, 4 };
        private int width;

        public GameGrid() : this(4, 4)
        {
        }

        public GameGrid(int x, int y)
        {
            this.width = (x > 0) ? x : 1;
            this.height = (y > 0) ? y : 1;
            this.Cells = new Cell[width, height];
            AddRandom();
        }

        public Cell[,] Cells
        {
            get; private set;
        }

        public int Height { get { return width; } }

        public int Width { get { return width; } }

        public void AddRandom()
        {
            var empty = GetEmptyCells();
            int r = rnd.Next(empty.Count);
            Cells[empty[r].X, empty[r].Y].Value = newvalues[rnd.Next(newvalues.Length)];
        }

        public bool Move(Direction dir)
        {
            bool hasMoved = false;

            for (int i = 0; i < width; i++)
            {
                int x = (dir == Direction.Right) ? width - 1 - i : i;
                for (int j = 0; j < height; j++)
                {
                    int y = (dir == Direction.Down) ? height - 1 - j : j;
                    if (Cells[x, y].Value > 0)
                    {
                        bool bResult = MoveCell(new GridPosition(x, y), dir);
                        if (bResult) hasMoved = true;
                    }
                }
            }
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Cells[i, j].hasMerged = false;
                }
            }
            return hasMoved;
        }

        public void PrintGrid()
        {
            for (int y = 0; y < Cells.GetLength(0); y++)
            {
                string strLine = "";
                for (int x = 0; x < Cells.GetLength(0); x++)
                {
                    strLine += Cells[x, y].Value.ToString();
                    if (x < Cells.GetLength(0) - 1)
                    {
                        strLine += ",";
                    }
                }
                Debug.WriteLine(strLine);
            }
        }

        private bool CollideCell(ref Cell a, ref Cell b)
        {
            if (b.Value == 0)
            {
                b.Value = a.Value;
                b.hasMerged = a.hasMerged;
                a.Reset();
                return true;
            }
            else if (a.Value == b.Value && !a.hasMerged && !b.hasMerged)
            {
                b.Value += a.Value;
                b.hasMerged = true;
                Score += b.Value;
                a.Reset();
                return true;
            }
            return false;
        }

        private List<GridPosition> GetEmptyCells()
        {
            List<GridPosition> empty = new List<GridPosition>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (Cells[i, j].Value == 0)
                    {
                        empty.Add(new GridPosition(i, j));
                    }
                }
            }
            return empty;
        }

        private bool MoveCell(GridPosition cell, Direction dir)
        {
            int nextY = cell.Y;
            int nextX = cell.X;
            switch (dir)
            {
                case Direction.Up:
                    nextY--;
                    break;

                case Direction.Down:
                    nextY++;
                    break;

                case Direction.Left:
                    nextX--;
                    break;

                case Direction.Right:
                    nextX++;
                    break;

                default:
                    return false;
            }
            if (nextX < 0 || nextY < 0 || nextX >= Cells.GetLength(0) || nextY >= Cells.GetLength(1)) //Out of array bounds, must have hit edge.
            {
                return false;
            }
            else
            {
                GridPosition nextCell = new GridPosition(nextX, nextY);
                if (CollideCell(ref Cells[cell.X, cell.Y], ref Cells[nextCell.X, nextCell.Y]))
                {
                    MoveCell(nextCell, dir);
                    return true;
                }
                return false;
            }
        }

        public bool MoveRequest(Direction dir)
        {
            bool moveResult = Move(dir);
            if (moveResult)
            {
                AddRandom();
                PrintGrid();
            }
            return moveResult;
        }

        public struct Cell
        {
            public bool hasMerged;
            public int Value;

            public void Reset()
            {
                Value = 0;
                hasMerged = false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Utilities
{
    public enum Direction { Up, Down, Left, Right }


    public struct GridPosition
    {
        public int X;
        public int Y;

        public GridPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

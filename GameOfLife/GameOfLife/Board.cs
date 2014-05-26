using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Board
    {
        private readonly bool[,] _board;

        public Board(IEnumerable<Point> points, int length, int width)
        {
            _board = new bool[length, width];

            foreach (var point in points)
            {
                var x = point.X;
                var y = point.Y;

                if (x < 0 || x >= length || y < 0 || y >= width)
                    throw new ArgumentOutOfRangeException();

                _board[x, y] = true;
            }
        }

        public bool IsAlive(int x, int y)
        {
            return _board[x, y];
        }
    }
}

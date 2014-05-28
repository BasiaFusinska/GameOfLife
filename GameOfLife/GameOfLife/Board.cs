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
        private readonly int _length;
        private readonly int _width;
        private readonly bool[,] _board;

        public Board(IEnumerable<Point> points, int length, int width)
        {
            _length = length;
            _width = width;
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

        public int CountNeighbours(int x, int y)
        {
            var neighboursCount = 0;

            for (var i = Math.Max(0, x - 1); i <= Math.Min(_length - 1, x + 1); i++)
            {
                for (var j = Math.Max(0, y - 1); j <= Math.Min(_width - 1, y + 1); j++)
                {
                    neighboursCount += IsAlive(i, j) ? 1 : 0;
                }
            }

            return neighboursCount - (IsAlive(x, y) ? 1 : 0);
        }

        public bool IsAlive(int x, int y)
        {
            return _board[x, y];
        }
    }
}

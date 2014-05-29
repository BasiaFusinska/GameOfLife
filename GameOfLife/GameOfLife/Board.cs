using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Board
    {
        private readonly bool[,] _board;

        public int Length { get; private set; }
        public int Width { get; private set; }

        public Board(IEnumerable<Point> points, int length, int width)
        {
            Length = length;
            Width = width;
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

        public void ForeachCell(Action<int, int> action)
        {
            for (var i = 0; i < Length; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    action(i, j);
                }
            }
        }

        public int CountNeighbours(int x, int y)
        {
            var neighboursCount = 0;

            for (var i = Math.Max(0, x - 1); i <= Math.Min(Length - 1, x + 1); i++)
            {
                for (var j = Math.Max(0, y - 1); j <= Math.Min(Width - 1, y + 1); j++)
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

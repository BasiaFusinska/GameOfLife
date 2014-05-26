using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameOfLife
{
    public class Game
    {
        private readonly int _length;
        private readonly int _width;
        private Board _board;

        public Game(IEnumerable<Point> points, int length, int width)
        {
            _length = length;
            _width = width;
            _board = new Board(points, length, width);
        }

        public void Step()
        {
            var points = new List<Point>();
            for (var i = 0; i < _length; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    if(ApplyRule(i, j))
                        points.Add(new Point(i, j));
                }
            }
            _board = new Board(points, _length, _width);
        }

        private bool ApplyRule(int x, int y)
        {
            var value = _board.IsAlive(x, y);
            var neighboursCount = CountNeighbours(x, y);

            return value ? neighboursCount > 1 && neighboursCount < 4 : neighboursCount == 3;
        }

        private int CountNeighbours(int x, int y)
        {
            var neighboursCount = 0;

            for (var i = Math.Max(0, x-1); i <= Math.Min(_length - 1, x+1); i++)
            {
                for (var j = Math.Max(0, y-1); j <= Math.Min(_width - 1, y+1); j++)
                {
                    neighboursCount += _board.IsAlive(i, j) ? 1 : 0;
                }
            }

            return neighboursCount - (_board.IsAlive(x, y) ? 1 : 0);
        }

        public bool IsAlive(int x, int y)
        {
            return _board.IsAlive(x, y);
        }
    }
}

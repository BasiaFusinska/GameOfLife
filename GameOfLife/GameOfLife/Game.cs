using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameOfLife
{
    public class Game
    {
        private Board _board;

        public Game(IEnumerable<Point> points, int length, int width)
        {
            _board = new Board(points, length, width);
        }

        public void Step()
        {
            var points = new List<Point>();

            _board.ForeachCell((i, j) =>
                {
                    if(ApplyRule(i, j))
                        points.Add(new Point(i, j));
                });


            _board = new Board(points, _board.Length, _board.Width);
        }

        private bool ApplyRule(int x, int y)
        {
            var isAlive = _board.IsAlive(x, y);
            var neighboursCount = _board.CountNeighbours(x, y);

            return isAlive ? neighboursCount > 1 && neighboursCount < 4 : neighboursCount == 3;
        }


        public bool IsAlive(int x, int y)
        {
            return _board.IsAlive(x, y);
        }
    }
}

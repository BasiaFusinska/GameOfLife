using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace GameOfLife
{
    public class Game
    {
        private readonly Board _board;

        public Game(Board board)
        {
            _board = board;
        }
    }
}

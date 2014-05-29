using System;
using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public static class BoardTestsHelper
    {
         public static void CellIsAlive(this Board board, int x, int y)
         {
             board.IsAlive(x, y).Should().BeTrue();
         }
 
         public static void CellIsDead(this Board board, int x, int y)
         {
             board.IsAlive(x, y).Should().BeFalse();
         }
     }
    public class BoardTests
    {
        [Fact]
        public void less_than_zero_coordinates_return_exception()
        {
            var points = new List<Point>
            {
                new Point(2, 2),
                new Point(-4, 4),
                new Point(6, 6)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => new Board(points, 10, 10));
        }

        [Fact]
        public void more_than_board_size_coordinates_return_exception()
        {
            var points = new List<Point>
            {
                new Point(2, 12),
                new Point(4, 4),
                new Point(6, 6)
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => new Board(points, 10, 10));
        }

        [Fact]
        public void proper_coordinates_create_game_board()
        {
            var points = new List<Point>
            {
                new Point(2, 2),
                new Point(4, 4),
                new Point(6, 6)
            };

            var board = new Board(points, 10, 10);

            AddedPointsShouldBeAlive(board);
            OtherPointsShouldBeDead(board);
        }

        private static void OtherPointsShouldBeDead(Board board)
        {
            board.CellIsDead(1, 3);
            board.CellIsDead(5, 2);
            board.CellIsDead(7, 4);
        }

        private static void AddedPointsShouldBeAlive(Board board)
        {
            board.CellIsAlive(2, 2);
            board.CellIsAlive(4, 4);
            board.CellIsAlive(6, 6);
        }
    }
}

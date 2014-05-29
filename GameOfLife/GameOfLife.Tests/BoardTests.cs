using System;
using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public static class BoardTestsHelper
    {
         public static void CellIsAlive(this Game game, int x, int y)
         {
             game.IsAlive(x, y).Should().BeTrue();
         }
 
         public static void CellIsDead(this Game game, int x, int y)
         {
             game.IsAlive(x, y).Should().BeFalse();
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

            Assert.Throws<ArgumentOutOfRangeException>(() => new Game(points, 10, 10));
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

            Assert.Throws<ArgumentOutOfRangeException>(() => new Game(points, 10, 10));
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

            var game = new Game(points, 10, 10);

            AddedPointsShouldBeAlive(game);
            OtherPointsShouldBeDead(game);
        }

        private static void OtherPointsShouldBeDead(Game game)
        {
            game.CellIsDead(1, 3);
            game.CellIsDead(5, 2);
            game.CellIsDead(7, 4);
        }

        private static void AddedPointsShouldBeAlive(Game game)
        {
            game.CellIsAlive(2, 2);
            game.CellIsAlive(4, 4);
            game.CellIsAlive(6, 6);
        }
    }
}

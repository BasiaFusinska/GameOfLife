using System;
using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
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

            board.IsAlive(new Point(2, 2)).Should().BeTrue();
            board.IsAlive(new Point(4, 4)).Should().BeTrue();
            board.IsAlive(new Point(6, 6)).Should().BeTrue();
            board.IsAlive(new Point(1, 3)).Should().BeFalse();
            board.IsAlive(new Point(5, 2)).Should().BeFalse();
            board.IsAlive(new Point(7, 4)).Should().BeFalse();
        }
    }
}

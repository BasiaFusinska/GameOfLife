using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Xunit.Extensions;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        public void separate_points_in_board_result_in_clean_board(int x, int y)
        {
            var game = new Game(new List<Point> {new Point(x, y)}, 3, 3);
            game.Step();

            for(var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    game.IsAlive(i, j).Should().BeFalse();
        }

        [Theory]
        [InlineData(0, 0, 1, 1)]
        [InlineData(0, 1, 1, 1)]
        [InlineData(0, 2, 1, 1)]
        [InlineData(1, 0, 1, 1)]
        [InlineData(1, 2, 1, 1)]
        [InlineData(2, 0, 1, 1)]
        [InlineData(2, 1, 1, 1)]
        [InlineData(2, 2, 1, 1)]
        public void less_than_two_neighbours_should_result_in_clean_board(int x1, int y1, int x2, int y2)
        {
            var game = new Game(new List<Point> { new Point(x1, y1), new Point(x2, y2) }, 3, 3);
            game.Step();

            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    game.IsAlive(i, j).Should().BeFalse();
            
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 1, 1)]
        [InlineData(0, 2, 0, 1, 1, 1)]
        [InlineData(0, 0, 1, 0, 1, 1)]
        [InlineData(0, 2, 1, 2, 1, 1)]
        [InlineData(2, 0, 1, 0, 1, 1)]
        [InlineData(2, 2, 1, 2, 1, 1)]
        [InlineData(0, 1, 1, 1, 2, 1)]
        [InlineData(1, 0, 1, 1, 1, 2)]
        public void two_neighbours_should_result_in_staying_alive(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var game = new Game(new List<Point> { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3) }, 3, 3);
            game.Step();

            game.IsAlive(x2, y2).Should().BeTrue();
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 1, 1, 1, 0)]
        [InlineData(0, 1, 0, 2, 1, 1, 1, 2)]
        [InlineData(1, 0, 1, 1, 2, 0, 2, 1)]
        [InlineData(1, 1, 1, 2, 2, 1, 2, 2)]
        [InlineData(1, 1, 0, 1, 1, 0, 1, 2)]
        [InlineData(1, 1, 0, 1, 1, 0, 2, 1)]
        [InlineData(1, 1, 0, 1, 1, 2, 2, 1)]
        [InlineData(1, 1, 1, 0, 1, 2, 2, 1)]
        public void three_neighbours_should_result_in_staying_alive(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            var game = new Game(new List<Point> { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3), new Point(x4, y4) }, 3, 3);
            game.Step();

            game.IsAlive(x1, y1).Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 1, 0, 1, 1, 0, 2, 1, 1, 2)]
        [InlineData(0, 1, 0, 0, 0, 2, 1, 0, 1, 1)]
        [InlineData(1, 0, 0, 0, 1, 1, 0, 1, 2, 0)]
        [InlineData(2, 1, 2, 0, 1, 1, 1, 0, 2, 2)]
        [InlineData(1, 2, 1, 1, 2, 1, 2, 2, 0, 2)]
        public void more_than_three_neighbours_should_result_in_death(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, int x5, int y5)
        {
            var game = new Game(new List<Point> { new Point(x1, y1), new Point(x2, y2), new Point(x3, y3), new Point(x4, y4), new Point(x5, y5) }, 3, 3);
            game.Step();

            game.IsAlive(x1, y1).Should().BeFalse();
        }
    }
}

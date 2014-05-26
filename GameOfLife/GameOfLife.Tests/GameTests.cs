using System.Collections.Generic;
using System.Drawing;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        [Fact]
        public void applying_first_rule_should_change_the_board()
        {
            var points = new List<Point>
            {
                new Point(0, 1),
                new Point(0, 4),
                new Point(1, 2),
                new Point(3, 1),
                new Point(4, 0),
                new Point(4, 1),
                new Point(4, 2),
            };

            var game = new Game(points, 5, 5);
            game.Step();

            game.IsAlive(0, 1).Should().BeFalse();
            game.IsAlive(0, 4).Should().BeFalse();
            game.IsAlive(1, 2).Should().BeFalse();
            game.IsAlive(2, 2).Should().BeFalse();
            game.IsAlive(3, 1).Should().BeTrue();
            game.IsAlive(4, 0).Should().BeTrue();
            game.IsAlive(4, 1).Should().BeTrue();
            game.IsAlive(4, 2).Should().BeTrue();
            game.IsAlive(4, 4).Should().BeFalse();
        }
    }
}

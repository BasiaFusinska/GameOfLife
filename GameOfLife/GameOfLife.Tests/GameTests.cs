using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameTests
    {
        [Fact]
        public void ApiTest()
        {
            var game = new Game();
            game.Play();
        }
    }
}

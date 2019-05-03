using System;
using Xunit;
using toy_robot;

namespace Tests
{
    public class DirectionTests
    {
        string InvalidDirectionError = "Invalid direction - must be one of NORTH, EAST, SOUTH, WEST";

        [Fact]
        public void InvalidSetDirectionThrowsInvalidDirectionError()
        {
            Direction dir = new Direction("NORTH");
            InvalidDirectionException exception = Assert.Throws<InvalidDirectionException>(() => dir.setDirection("NOT A DIRECTION"));
            Assert.Equal(InvalidDirectionError, exception.Message);
        }

        [Fact]
        public void InvalidDirectionInitThrowsInvalidDirectionError()
        {
            InvalidDirectionException exception = Assert.Throws<InvalidDirectionException>(() => { Direction t = new Direction("NOT A DIRECTION"); });
            Assert.Equal(InvalidDirectionError, exception.Message);
        }

        [Fact]
        public void TurnsLeftCorrectly()
        {
            Direction direction = new Direction("NORTH");
            direction.left();
            Assert.Equal("EAST", direction.toString());
            direction.left();
            Assert.Equal("SOUTH", direction.toString());
            direction.left();
            Assert.Equal("WEST", direction.toString());
            direction.left();
            Assert.Equal("NORTH", direction.toString());
        }

        [Fact]
        public void TurnsRightCorrectly()
        {
            Direction direction = new Direction("NORTH");
            direction.right();
            Assert.Equal("WEST", direction.toString());
            direction.right();
            Assert.Equal("SOUTH", direction.toString());
            direction.right();
            Assert.Equal("EAST", direction.toString());
            direction.right();
            Assert.Equal("NORTH", direction.toString());
        }
    }
}

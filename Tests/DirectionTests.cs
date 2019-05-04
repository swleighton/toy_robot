using System;
using Xunit;
using toy_robot;
using System.Collections.Generic;

namespace Tests
{
    public class DirectionTests
    {
        string InvalidDirectionError = "Invalid direction - must be one of NORTH, EAST, SOUTH, WEST";

        [Fact]
        public void InvalidDirectionInitThrowsInvalidDirectionError()
        {
            InvalidDirectionException exception = Assert.Throws<InvalidDirectionException>(() => { Direction t = new Direction("NOT A DIRECTION"); });
            Assert.Equal(InvalidDirectionError, exception.Message);
        }

        [Fact]
        public void TurnsRightCorrectly()
        {
            Direction direction = new Direction("NORTH");

            Assert.Equal("EAST", direction.TurnRight());
            Assert.Equal("SOUTH", direction.TurnRight()); ;
            Assert.Equal("WEST", direction.TurnRight());
            Assert.Equal("NORTH", direction.TurnRight());
        }

        [Fact]
        public void TurnsLeftCorrectly()
        {
            Direction direction = new Direction("NORTH");

            Assert.Equal("WEST", direction.TurnLeft());
            Assert.Equal("SOUTH", direction.TurnLeft());
            Assert.Equal("EAST", direction.TurnLeft());
            Assert.Equal("NORTH", direction.TurnLeft());
        }

        [Fact]
        public void ReturnsCorrectListOfDirections()
        {
            Assert.Equal(
                new List<string>(new string[]{
                    "NORTH",
                    "EAST",
                    "SOUTH",
                    "WEST"
                }),
                Direction.GetValidDirections()
            );
        }

    }
}

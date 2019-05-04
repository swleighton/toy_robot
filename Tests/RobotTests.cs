using System;
using Xunit;
using toy_robot;

namespace Tests
{
    public class RobotTests
    {
        private readonly string InvalidDirectionError = "Invalid direction - must be one of NORTH, EAST, SOUTH, WEST";

        [Fact]
        public void ThrowsRobotNotPlacedExceptionWhenTurningLeftWithoutPlacement()
        {
            Robot robot = new Robot();
            Assert.Throws<RobotNotPlacedException>(() => robot.TurnLeft());
        }

        [Fact]
        public void ThrowsRobotNotPlacedExceptionWhenTurningRightWithoutPlacement()
        {
            Robot robot = new Robot();
            Assert.Throws<RobotNotPlacedException>(() => robot.TurnRight());
        }

        [Fact]
        public void ThrowsRobotNotPlacedExceptionWhenMovingWithoutPlacement()
        {
            Robot robot = new Robot();
            Assert.Throws<RobotNotPlacedException>(() => robot.Move());
        }

        [Fact]
        public void ThrowsRobotNotPlacedExceptionWhenLocationIsOutputWithoutPlacement()
        {
            Robot robot = new Robot();
            Assert.Throws<RobotNotPlacedException>(() => robot.Location());
        }

        [Fact]
        public void PlacesCorrectly()
        {
            Robot robot = new Robot();
            robot.Place(1, 2, "NORTH");
            Assert.Equal("Output: 1,2,NORTH", robot.Location());
        }

        [Fact]
        public void ThrowsPositionNotOnBoardExceptionForInvalidPlacement()
        {
            Robot robot = new Robot();
            Assert.Throws<PositionNotOnBoardException>(() => { robot.Place(6, 6, "NORTH"); });
        }

        [Fact]
        public void TurnsLeftCorrectly()
        {
            Robot robot = new Robot();
            robot.Place(0, 0, "NORTH");

            Assert.Equal("EAST", robot.TurnLeft());
            Assert.Equal("SOUTH", robot.TurnLeft());
            Assert.Equal("WEST", robot.TurnLeft());
            Assert.Equal("NORTH", robot.TurnLeft());
        }

        [Fact]
        public void TurnsRightCorrectly()
        {
            Robot robot = new Robot();
            robot.Place(0, 0, "NORTH");

            Assert.Equal("WEST", robot.TurnRight());
            Assert.Equal("SOUTH", robot.TurnRight());
            Assert.Equal("EAST", robot.TurnRight());
            Assert.Equal("NORTH", robot.TurnRight());
        }

        [Fact]
        public void MovesNorthCorrectly()
        {
            Robot robot = new Robot();
            robot.Place(0, 0, "NORTH");
            robot.Move();
            Assert.Equal(1, robot.YPosition);
        }

        [Fact]
        public void MovesEastCorrectly()
        {
            Robot robot = new Robot();
            robot.Place(0, 0, "EAST");
            robot.Move();
            Assert.Equal(1, robot.XPosition);
        }

        [Fact]
        public void MovesSouthCorrectly()
        {
            Robot robot = new Robot();
            robot.Place(0, 1, "SOUTH");
            robot.Move();
            Assert.Equal(0, robot.YPosition);
        }

        [Fact]
        public void MovesWestCorrectly()
        {
            Robot robot = new Robot();
            robot.Place(1, 0, "WEST");
            robot.Move();
            Assert.Equal(0, robot.XPosition);
        }

    }
}

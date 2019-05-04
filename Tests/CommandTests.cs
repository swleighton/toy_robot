using System;
using Xunit;
using toy_robot;

namespace Tests
{
    public class CommandTests
    {
        [Fact]
        public void MoveEndToEndTest()
        {
            Command command = new Command(new Robot());

            command.Execute("PLACE 0,0,NORTH");
            command.Execute("MOVE");
            Assert.Equal("Output: 0,1,NORTH", command.Execute("REPORT"));
        }

        [Fact]
        public void DirectionEndToEndTest()
        {
            Command command = new Command(new Robot());

            command.Execute("PLACE 0,0,NORTH");
            command.Execute("LEFT");
            Assert.Equal("Output: 0,0,WEST", command.Execute("REPORT"));
        }

        [Fact]
        public void CompleteEndToEndTest() 
        { 
             Command command = new Command(new Robot());

            command.Execute("PLACE 1,2,EAST");
            command.Execute("MOVE");
            command.Execute("MOVE");
            command.Execute("LEFT");
            command.Execute("MOVE");

            Assert.Equal("Output: 3,3,NORTH", command.Execute("REPORT"));

            command.Execute("PLACE 0,0,EAST");
            command.Execute("MOVE");
            command.Execute("MOVE");
            command.Execute("RIGHT");

            Assert.Equal("Output: 2,0,SOUTH", command.Execute("REPORT"));
        }

        [Fact]
        public void PlaceCommandPlacesRobot()
        {
            Robot robot = new Robot();
            Command command = new Command(robot);

            Assert.Equal("Robot was placed at: 0,0,NORTH", command.Execute("PLACE 0,0,NORTH"));
            Assert.Equal("Robot was placed at: 2,1,WEST", command.Execute("PLACE 2,1,WEST"));
        }

        [Fact]
        public void MoveCommandMovesRobot()
        {
            Robot robot = new Robot();
            Command command = new Command(robot);

            robot.Place(0, 0, "NORTH");

            Assert.Equal("Robot moved to: 0,1,NORTH", command.Execute("MOVE"));
            Assert.Equal("Robot moved to: 0,2,NORTH", command.Execute("MOVE"));
        }

        [Fact]
        public void LeftCommandMovesRobotLeft()
        {
            Robot robot = new Robot();
            Command command = new Command(robot);

            robot.Place(0, 0, "NORTH");

            Assert.Equal("Robot is now facing WEST", command.Execute("LEFT"));
            Assert.Equal("Robot is now facing SOUTH", command.Execute("LEFT"));
        }

        [Fact]
        public void RightCommandMovesRobotRight()
        {
            Robot robot = new Robot();
            robot.Place(0, 0, "NORTH");

            Command command = new Command(robot);

            Assert.Equal("Robot is now facing EAST", command.Execute("RIGHT"));
            Assert.Equal("Robot is now facing SOUTH", command.Execute("RIGHT"));
        }

        [Fact]
        public void ReportCommandOutputsRobotLocation()
        {
            Robot robot = new Robot();
            Command command = new Command(robot);

            robot.Place(0, 0, "NORTH");
            Assert.Equal("Output: 0,0,NORTH", command.Execute("REPORT"));

            robot.Place(3, 3, "EAST");
            Assert.Equal("Output: 3,3,EAST", command.Execute("REPORT"));
        }

        [Fact]
        public void ThrowsRobotNotPlacedExceptionWhenMoveCommandWithoutPlacement()
        {
            Assert.Throws<RobotNotPlacedException>(() => new Command(new Robot()).Execute("MOVE"));
        }

        [Fact]
        public void ThrowsRobotNotPlacedExceptionWhenLeftCommandWithoutPlacement()
        {
            Assert.Throws<RobotNotPlacedException>(() => new Command(new Robot()).Execute("LEFT"));
        }

        [Fact]
        public void ThrowsRobotNotPlacedExceptionWhenRightCommandWithoutPlacement()
        {
            Assert.Throws<RobotNotPlacedException>(() => new Command(new Robot()).Execute("RIGHT"));
        }

        [Fact]
        public void ThrowsRobotNotPlacedExceptionWhenReportCommandWithoutPlacement()
        {
            Assert.Throws<RobotNotPlacedException>(() => new Command(new Robot()).Execute("REPORT"));
        }

        [Fact]
        public void ThrowsInvalidCommandExceptionWithInvalidCommand()
        {
            Assert.Throws<InvalidCommandException>(() => new Command(new Robot()).Execute("NOT A VALID COMMAND"));
        }

        [Fact]
        public void ThrowsInvalidCommandExceptionWithInvalidPlaceXCoordinateCommand()
        {
            Assert.Throws<InvalidCommandException>(() => new Command(new Robot()).Execute("PLACE X,1,NORTH"));
        }

        [Fact]
        public void ThrowsInvalidCommandExceptionWithInvalidPlaceYCoordinateCommand()
        {
            Assert.Throws<InvalidCommandException>(() => new Command(new Robot()).Execute("PLACE 0,Y,NORTH"));
        }

        [Fact]
        public void ThrowsInvalidCommandExceptionWithInvalidPlaceDirectionCommand()
        {
            Assert.Throws<InvalidCommandException>(() => new Command(new Robot()).Execute("PLACE 0,0,NOTADIRECTION"));
        }

        [Fact]
        public void InvalidCommandExceptionWithMultispaceInvalidPlaceDirectionCommand()
        {
            Assert.Throws<InvalidCommandException>(() => new Command(new Robot()).Execute("PLACE 0,0 ,NORTH"));
        }
    }
}

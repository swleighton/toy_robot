using System;
namespace toy_robot
{
    public class Command
    {
        private string invalidCommandExceptionMessage = "";
        private Robot robot;

        public Command(Robot robot) => this.robot = robot;

        public string Execute(string command)
        {
            command = command.ToUpper().Trim();

            if (command == "MOVE")
            {
                robot.Move();
                return robot.Location();
            }
            else if (command == "LEFT")
            {
                return robot.TurnLeft();
            }
            else if (command == "RIGHT")
            {
                return robot.TurnRight();
            }
            else if (command.StartsWith("PLACE"))
            {
                 buildPlaceArgsFromCommand(command, robot);
                return robot.Location();
            }
            else if (command == "REPORT")
            {
                return robot.Location();
            }
            else
            {
                throw new InvalidCommandException(invalidCommandExceptionMessage);
            }

 
        }

        private void buildPlaceArgsFromCommand(string command, Robot robot)
        {
            try
            {

                string[] commandaArgsSplit = command.Split(" ")[1].Split(",");
                robot.Place(int.Parse(commandaArgsSplit[0]), int.Parse(commandaArgsSplit[1]), commandaArgsSplit[2]);
            }
            catch (Exception)
            {
                throw new InvalidCommandException(invalidCommandExceptionMessage);
            }
        }
    }
}

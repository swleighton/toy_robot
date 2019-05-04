using System;
namespace toy_robot
{
    public class Command
    {
        private string invalidCommandExceptionMessage = "Invalid command";
        private Robot robot;

        public Command(Robot robot) => this.robot = robot;

        public string Execute(string command)
        {
            command = command.ToUpper().Trim();

            if (command == "MOVE")
            {
                robot.Move();
                return $"Robot moved to: {robot.Location()}";
            }
            else if (command == "LEFT")
            {
                return $"Robot is now facing {robot.TurnLeft()}";
            }
            else if (command == "RIGHT")
            {
                return $"Robot is now facing {robot.TurnRight()}";
            }
            else if (command.StartsWith("PLACE"))
            {
                BuildPlaceArgsFromCommand(command);
                return $"Robot was placed at: {robot.Location()}";
            }
            else if (command == "REPORT")
            {
                return $"Output: {robot.Location()}";
            }
            else if (command == "EXIT")
            {
                Environment.Exit(0);
                return "";
            }
            else
            {
                throw new InvalidCommandException(invalidCommandExceptionMessage);
            }


        }

        private void BuildPlaceArgsFromCommand(string command)
        {
            try
            {

                string[] commandArgsSplit = command.Split(" ")[1].Split(",");
                robot.Place(int.Parse(commandArgsSplit[0]), int.Parse(commandArgsSplit[1]), commandArgsSplit[2]);
            }
            catch (Exception)
            {
                throw new InvalidCommandException(invalidCommandExceptionMessage);
            }
        }
    }
}

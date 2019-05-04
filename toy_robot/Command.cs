using System;
namespace toy_robot
{
    public class Command
    {
        private readonly string invalidCommandExceptionMessage = "Invalid command";
        private Robot robot;

        public Command(Robot robot) => this.robot = robot;

        /// <summary>
        /// Parses the passed command to call the correct robot method
        /// </summary>
        /// <param name="command">The command string to be parsed</param>  
        /// <exception cref="InvalidCommandException">If a valid command is not supplied</exception>
        /// <exception cref="RobotNotPlacedException">If any command other than place and exit is supplied before the robot is placed</exception>
        /// <exception cref="PositionNotOnBoardException">If place or move command is supplied that will result in the robot not being/remaining on the board</exception>
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

        /// <summary>
        /// Parses a place command and calls the robot's place method
        /// </summary>
        /// <param name="command">The Place command string to be parsed into the robots place method params</param>  
        ///<exception cref="InvalidCommandException">If a valid place command is not supplied</exception>
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

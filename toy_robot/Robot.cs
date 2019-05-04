using System;
namespace toy_robot
{
    public class Robot
    {
        public int YPosition { get; private set; }
        public int XPosition { get; private set; }
        public bool Placed { get; private set; }

        private readonly int MaxXPosition = 5;
        private readonly int MaxYPosition = 5;
        private Direction direction;
        private readonly string PositionNotOnBoardExceptionMessage = "This action was skipped as the robot would be off of the board";
        private readonly string RobotNotPlacedExceptionMessage = "Robot must be placed on the board to undertake this action";
        private enum TurnDirection
        {
            LEFT,
            RIGHT
        };

        /// <summary>
        /// Turns the robot left
        /// </summary>
        /// <returns>Returns the current direction after turning left</returns>
        /// <exception cref="RobotNotPlacedException">If the robot has not been placed</exception>
        public string TurnLeft() => Turn(TurnDirection.LEFT);

        /// <summary>
        /// Turns the robot right
        /// </summary>
        /// <returns>Returns the current direction after turning right</returns>
        /// <exception cref="RobotNotPlacedException">If the robot has not been placed</exception>
        public string TurnRight() => Turn(TurnDirection.RIGHT);

        /// <summary>
        /// Places the robot at the passed x,y coordinates facing the passed direction
        /// </summary>
        /// <param name="xPosition">The X coordinate</param>
        /// <param name="yPosition">The Y coordinate</param>
        /// <param name="direction">The direction the robot should face</param>
        /// <exception cref="PositionNotOnBoardException">If the passed Coordinates are not on the board</exception>
        public void Place(int xPosition, int yPosition, string direction)
        {

            if (xPosition >= 0 && xPosition <= MaxXPosition && yPosition >= 0 && yPosition <= MaxYPosition)
            {
                this.direction = new Direction(direction);
                this.XPosition = xPosition;
                this.YPosition = yPosition;
                this.Placed = true;
            }
            else
            {
                throw new PositionNotOnBoardException(PositionNotOnBoardExceptionMessage);
            }
        }


        /// <summary>
        /// Gets the current X,Y coordinates and direction of the robot
        /// </summary>
        /// <returns>Returns a string of the X,Y coordinates and direction of the robot in the format X,Y,D</returns>
        /// <exception cref="RobotNotPlacedException">If the robot has not been placed</exception>
        public string Location()
        {
            if (Placed)
            {
                return $"{XPosition},{YPosition},{direction}";
            }
            else
            {
                throw new RobotNotPlacedException(RobotNotPlacedExceptionMessage);
            }
        }

        /// <summary>
        /// Moves the robot one square in the current direction
        /// </summary>
        /// <exception cref="RobotNotPlacedException">If the robot has not been placed</exception>
        /// <exception cref="PositionNotOnBoardException">If moving the robot will result in it not remianing on the board</exception>
        public void Move()
        {
            if (Placed)
            {
                switch (direction.ToString())
                {
                    case "NORTH":
                        YPosition = UpdatePosition(YPosition, MaxYPosition, 1);
                        break;
                    case "EAST":
                        XPosition = UpdatePosition(XPosition, MaxXPosition, 1);
                        break;
                    case "SOUTH":
                        YPosition = UpdatePosition(YPosition, 0, -1);
                        break;
                    case "WEST":
                        XPosition = UpdatePosition(XPosition, 0, -1);
                        break;
                }
            }
            else
            {
                throw new RobotNotPlacedException(RobotNotPlacedExceptionMessage);
            }
        }

        /// <summary>
        /// Updates the passed position of the robot by the passed amount
        /// </summary>
        /// <param name="position">The current position</param>
        /// <param name="bound">The max value allowed for the passed position</param>
        /// <param name="position">The amount to update the position by</param>
        /// <returns>Returns the new position value</returns>
        /// <exception cref="PositionNotOnBoardException">If the movement will mean the robot will no longer be on the board</exception>
        private int UpdatePosition(int position, int bound, int moveAmount)
        {
            if ((position > bound && moveAmount < 0) || (position < bound && moveAmount > 0))
            {
                return position + moveAmount;
            }
            else
            {
                throw new PositionNotOnBoardException(PositionNotOnBoardExceptionMessage);
            }
        }

        /// <summary>
        /// Turns the robot in the passed direction
        /// </summary>
        /// <param name="turnDirection">The turn direction</param>
        /// <returns>Returns the current direction after turning or the current direction again if the turn was not made</returns>
        /// <exception cref="RobotNotPlacedException">If the robot has not been placed</exception>
        private string Turn(TurnDirection turnDirection)
        {
            if (Placed)
            {
                if (turnDirection == TurnDirection.LEFT)
                {
                    return direction.TurnLeft();
                }
                else if (turnDirection == TurnDirection.RIGHT)
                {
                    return direction.TurnRight();
                }
                else
                {
                    return direction.ToString();
                }
            }
            else
            {
                throw new RobotNotPlacedException(RobotNotPlacedExceptionMessage);
            }
        }

    }
}

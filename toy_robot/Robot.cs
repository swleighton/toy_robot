using System;
namespace toy_robot
{
    public class Robot
    {
        public Robot()
        {


        }

        public int YPosition { get; private set; }
        public int XPosition { get; private set; }
        public bool Placed { get; private set; }

        private readonly int MaxXPosition = 5;
        private readonly int MaxYPosition = 5;
        private Direction direction;
        private readonly string PositionNotOnBoardExceptionMessage = "";
        private readonly string RobotNotPlacedExceptionMessage = ""; 
        private enum TurnDirection
        {
            LEFT,
            RIGHT
        };

        public string TurnLeft() => Turn(TurnDirection.LEFT);

        public string TurnRight() => Turn(TurnDirection.RIGHT);

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

        public string Location()
        {
            if (Placed)
            {
                return $"Output: {XPosition},{YPosition},{direction}";
            }
            else
            {
                throw new PositionNotOnBoardException(PositionNotOnBoardExceptionMessage);
            }
        }

        public void Move()
        {
            if (Placed)
            {
                switch (direction.ToString())
                {
                    case "NORTH":
                        YPosition = Move(YPosition, MaxYPosition, 1);
                        break;
                    case "EAST":
                        XPosition = Move(XPosition, MaxXPosition, 1);
                        break;
                    case "SOUTH":
                        YPosition = Move(YPosition, 0, -1);
                        break;
                    case "WEST":
                        XPosition = Move(XPosition, 0, -1);
                        break;
                }
            } else
            {
                throw new RobotNotPlacedException(RobotNotPlacedExceptionMessage);
            }
        }

        private int Move(int position, int bound, int moveAmmount)
        {
            if ((position > bound && moveAmmount < 0) || (position < bound && moveAmmount > 0))
            {
                return position + moveAmmount;
            }
            else
            {
                throw new PositionNotOnBoardException(PositionNotOnBoardExceptionMessage);
            }
        }

        private string Turn(TurnDirection turnDirection)
        {
            if (Placed) {
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
            } else {
                throw new RobotNotPlacedException(RobotNotPlacedExceptionMessage);
            }
    }

    }
}

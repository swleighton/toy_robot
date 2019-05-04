using System.Collections.Generic;

namespace toy_robot
{
    public class Direction
    {
        private static readonly List<string> directions = new List<string>(new string[]{
            "NORTH",
            "EAST",
            "SOUTH",
            "WEST"
        });

        private int currentDirection;

        public Direction(string direction) => SetDirection(direction);

        public void SetDirection(string direction)
        {
            int directionIndex = ValidateDirection(direction.ToUpper().Trim());

            if (directionIndex != -1)
            {
                currentDirection = directionIndex;
            } else
            {
            throw new InvalidDirectionException($"Invalid direction - must be one of {string.Join(", ", GetValidDirections().ToArray())}");
            }
        }

        public string TurnLeft()
        {
            if (currentDirection == directions.Count - 1)
            {
                currentDirection = 0;
            }
            else
            {
                currentDirection++;
            }

            return ToString();
        }

        public string TurnRight()
        {
            if (currentDirection == 0)
            {
                currentDirection = directions.Count - 1;
            }
            else
            {
                currentDirection--;
            }

            return ToString();
        }

        public static int ValidateDirection(string direction) => directions.IndexOf(direction.ToUpper().Trim());

        public override string ToString() => directions[currentDirection];

        public List<string> GetValidDirections() => directions;
    }
}
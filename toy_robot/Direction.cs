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

        public Direction(string direction)
        {
            setDirection(direction);
        }

        public void setDirection(string direction)
        {
            int directionIndex = validateDirection(direction.ToUpper().Trim());

            if (directionIndex != -1)
            {
                currentDirection = directionIndex;
            } else
            {
            throw new InvalidDirectionException($"Invalid direction - must be one of {string.Join(", ", getValidDirections().ToArray())}");
            }
        }

        public void left()
        {
            if (currentDirection == directions.Count - 1)
            {
                currentDirection = 0;
            }
            else
            {
                currentDirection++;
            }
        }

        public void right()
        {
            if (currentDirection == 0)
            {
                currentDirection = directions.Count -1;
            }
            else
            {
                currentDirection--;
            }
        }

        public static int validateDirection(string direction)
        {
            return directions.IndexOf(direction.ToUpper().Trim());
        }

        public string toString()
        {
            return directions[currentDirection];
        }

        public List<string> getValidDirections()
        {
            return directions;
        }
    }
}
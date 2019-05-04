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

        private int currentDirectionIndex;

        /// <summary>
        /// Validates and sets the  current direction 
        /// </summary>
        /// <param name="direction">valid direction string</param>  
        ///<exception cref="InvalidDirectionException">If a valid direction is not provided </exception>
        public Direction(string direction)
        {
            int directionIndex = directions.IndexOf(direction.ToUpper().Trim());

            if (directionIndex != -1)
            {
                currentDirectionIndex = directionIndex;
            }
            else
            {
                throw new InvalidDirectionException($"Invalid direction - must be one of {string.Join(", ", GetValidDirections().ToArray())}");
            }
        }

        /// <summary>
        /// Sets the direction to the right of the current direction
        /// </summary>
        /// <returns>Returns the name of the current direction as a string</returns>  
        public string TurnRight()
        {
            if (currentDirectionIndex == directions.Count - 1)
            {
                currentDirectionIndex = 0;
            }
            else
            {
                currentDirectionIndex++;
            }

            return ToString();
        }

        /// <summary>
        /// Sets the direction to the left of the current direction
        /// </summary>
        /// <returns>Returns the name of the current direction as a string</returns>  
        public string TurnLeft()
        {
            if (currentDirectionIndex == 0)
            {
                currentDirectionIndex = directions.Count - 1;
            }
            else
            {
                currentDirectionIndex--;
            }

            return ToString();
        }

        /// <summary>
        /// Gets name of the current direction
        /// </summary>
        /// <returns>Returns the name of the current direction as a string</returns> 
        public override string ToString() => directions[currentDirectionIndex];

        /// <summary>
        /// A list of valid directions
        /// </summary>
        /// <returns>Returns a List<String> of valid directions ordered right from NORTH</returns> 
        public static List<string> GetValidDirections() => directions;
    }
}
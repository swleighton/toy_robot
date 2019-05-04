using System;

public class RobotNotPlacedException : Exception
{
    public RobotNotPlacedException(string message) : base(message)
    {
    }
}
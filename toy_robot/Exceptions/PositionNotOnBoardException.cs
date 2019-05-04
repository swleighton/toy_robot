using System;

public class PositionNotOnBoardException : Exception
{
    public PositionNotOnBoardException(string message) : base(message)
    {
    }
}
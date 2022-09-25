using System;

namespace CommandPattern.Exceptions
{
    public class InvalidCommandType : Exception
    {
        public InvalidCommandType(string message)
            : base(message)
        {

        }
    }
}

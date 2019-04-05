namespace developer0223.Utility.Exceptions
{
    // C#
    using System;

    public class CannotFindException : Exception
    {
        public CannotFindException() : base() { }
        public CannotFindException(string message) : base(message) { }
        public CannotFindException(string message, Exception innerException) : base(message, innerException) { }
    }
}
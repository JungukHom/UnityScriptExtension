namespace developer0223.Utilities.Exceptions
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
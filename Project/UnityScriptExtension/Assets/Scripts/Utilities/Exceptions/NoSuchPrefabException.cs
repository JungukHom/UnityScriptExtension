namespace developer0223.Utilities.Exceptions
{
    // C#
    using System;

    public class NoSuchPrefabException : Exception
    {
        public NoSuchPrefabException() : base() { }
        public NoSuchPrefabException(string message) : base(message) { }
        public NoSuchPrefabException(string message, Exception innerException) : base(message, innerException) { }
    }
}
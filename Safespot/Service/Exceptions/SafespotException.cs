namespace Safespot.Service.Exceptions
{
    public class SafespotException : Exception
    {
        public SafespotException(string message, int code) : base(message)
        { }
    }
}

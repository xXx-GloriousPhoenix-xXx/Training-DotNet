namespace Basics.OOP.Exceptions;

public class LibrarySavingException : Exception
{
    public LibrarySavingException() { }
    public LibrarySavingException(string message) : base(message) { }
    public LibrarySavingException(string message, Exception innerException) : base(message, innerException) { }
}

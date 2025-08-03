namespace Basics.OOP.Exceptions;

public class LibraryLoadingException : Exception
{
    public LibraryLoadingException() { }
    public LibraryLoadingException(string message) : base(message) { }
    public LibraryLoadingException(string message, Exception innerException) : base(message, innerException) { }
}
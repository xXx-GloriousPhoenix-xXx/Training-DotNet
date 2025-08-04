namespace Basics.Exceptions;

public class AuthorNotFoundException : Exception
{
    public AuthorNotFoundException() { }
    public AuthorNotFoundException(string message) : base(message) { }
    public AuthorNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}

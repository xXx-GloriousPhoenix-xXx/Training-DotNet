namespace Basics.Exceptions;

public class TitleNotFoundException : Exception
{
    public TitleNotFoundException() { }
    public TitleNotFoundException(string message) : base(message) { }
    public TitleNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}

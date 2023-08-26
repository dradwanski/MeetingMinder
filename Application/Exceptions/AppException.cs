namespace Application.Exceptions;

public abstract class AppException : Exception
{
    protected AppException(string exception) : base(exception)
    {

    }
}
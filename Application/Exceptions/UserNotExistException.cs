namespace Application.Exceptions
{
    public class UserNotExistException : ApplicationException
    {
        public UserNotExistException(string exception) : base(exception)
        {
        }

    }
}

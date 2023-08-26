namespace Application.Exceptions
{
    public class UserNotExistException : AppException
    {
        public UserNotExistException(string exception) : base(exception)
        {
        }

    }
}

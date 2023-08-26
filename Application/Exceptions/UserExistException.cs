namespace Application.Exceptions
{
    public class UserExistException : AppException
    {
        public UserExistException(string exception) : base(exception)
        {
        }

    }
}

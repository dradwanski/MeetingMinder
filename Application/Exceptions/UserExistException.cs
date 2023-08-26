namespace Application.Exceptions
{
    public class UserExistException : ApplicationException
    {
        public UserExistException(string exception) : base(exception)
        {
        }

    }
}

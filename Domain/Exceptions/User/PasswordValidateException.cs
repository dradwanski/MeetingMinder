namespace Domain.Exceptions.User
{
    public class PasswordValidateException : DomainException
    {
        public PasswordValidateException(string exception) : base(exception)
        {
        }
    }
}

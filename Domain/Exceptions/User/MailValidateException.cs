namespace Domain.Exceptions.User
{
    public class MailValidateException : DomainException
    {
        public MailValidateException(string exception) : base(exception)
        {
        }
    }
}

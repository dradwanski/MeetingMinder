using Domain.Exceptions.User;

namespace Domain.ValueObjects.User
{
    public record Email
    {
        public string Value { get; private set; }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new MailValidateException("Email is null or white space");
            }
            try
            {
                
                new System.Net.Mail.MailAddress(email);
                Value = email;
            }
            catch
            {
                throw new MailValidateException("Invalid email");
            }
        }
    }
}

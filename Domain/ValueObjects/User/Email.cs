using Domain.Exceptions.User;

namespace Domain.ValueObjects.User
{
    public class Email
    {
        public string _email { get; private set; }

        public Email(string email)
        {
            try
            {
                new System.Net.Mail.MailAddress(email);
                _email = email;
            }
            catch
            {
                throw new MailValidateException("Invalid email");
            }
        }
    }
}

using Domain.Exceptions.User;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects.User
{
    public record Password
    {
        public string Value { get; private set; }
        Regex ValidatePassword = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

        public Password(string password)
        {

            if (string.IsNullOrWhiteSpace(password) || !ValidatePassword.IsMatch(password))
            {
                throw new PasswordValidateException("Invalid password");
            }

            Value = password;




        }
    }
}

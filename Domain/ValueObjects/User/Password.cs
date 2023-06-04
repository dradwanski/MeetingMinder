using Domain.Exceptions.User;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects.User
{
    public class Password
    {
        public string _password { get; private set; }
        Regex ValidatePassword = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

        public Password(string password)
        {

            if (!ValidatePassword.IsMatch(password))
            {
                throw new PasswordValidateException("Invalid password");
            }

            _password = password;




        }
    }
}

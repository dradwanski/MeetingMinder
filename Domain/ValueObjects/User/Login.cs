using Domain.Exceptions.User;

namespace Domain.ValueObjects.User
{
    public class Login
    {
        public string _login { get; private set; }
        public Login(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new LoginNullException("LastName cannot be null");
            }
            _login = login;
        }
    }
}

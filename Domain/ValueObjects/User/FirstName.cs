using Domain.Exceptions.User;

namespace Domain.ValueObjects.User
{
    public class FirstName
    {
        public string _FirstName { get; private set; }
        public FirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new FirstNameNullException("FirstName cannot be null");
            }
            _FirstName = firstName;
        }
    }
}

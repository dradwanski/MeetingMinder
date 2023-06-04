using Domain.Exceptions.User;

namespace Domain.ValueObjects.User
{
    public class LastName
    {
        public string _LastName { get; private set; }
        public LastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new LastNameNullException("LastName cannot be null");
            }
            _LastName = lastname;
        }
    }
}

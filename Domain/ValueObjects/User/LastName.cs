using Domain.Exceptions.User;

namespace Domain.ValueObjects.User
{
    public record LastName
    {
        public string Name { get; private set; }
        public LastName(string lastname)
        {
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new LastNameException("LastName cannot be null");
            }
            Name = lastname;
        }
    }
}

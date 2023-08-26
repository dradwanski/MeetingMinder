using Domain.Exceptions.User;

namespace Domain.ValueObjects.User
{
    public record LastName
    {
        public string Value { get; init; }
        public LastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new LastNameException("LastName cannot be null");
            }
            
            Value = lastName;
        }
    }
}

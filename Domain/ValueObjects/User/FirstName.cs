using Domain.Exceptions.User;

namespace Domain.ValueObjects.User
{
    public record FirstName
    {
        public string Value { get; init; }
        public FirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Any(ch => !char.IsLetter(ch)))
            {
                throw new FirstNameException("FirstName cannot be null");
            }
            
            Value = firstName;
        }

    }
}

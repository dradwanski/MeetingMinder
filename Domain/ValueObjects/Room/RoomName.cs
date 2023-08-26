using Domain.Exceptions.User;

namespace Domain.ValueObjects.Room
{
    public class RoomName
    {
        public string Value { get; private set; }
        public RoomName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new FirstNameException("Value of room cannot be null");
            }
            Value = value;
        }
    }
}

using Domain.Exceptions.User;
using Domain.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

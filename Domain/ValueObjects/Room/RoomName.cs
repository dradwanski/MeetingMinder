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
        public string Name { get; private set; }
        public RoomName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new FirstNameException("Name of room cannot be null");
            }
            Name = name;
        }
    }
}

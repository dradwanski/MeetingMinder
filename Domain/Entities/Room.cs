using Domain.ValueObjects.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; private set; }
        public RoomName Name { get; private set; }

        private Room()
        {
            
        }

        public Room(string name)
        {
            Name = new RoomName(name);
        }

        public void SetName(string name)
        {
            Name = new RoomName(name);
        }

    }
}

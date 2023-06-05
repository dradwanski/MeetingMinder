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
        public RoomStatus Status { get; private set; }

        private Room()
        {
            
        }

        public Room(string name, RoomStatus status)
        {
            Name = new RoomName(name);
            Status = status;
        }

        public void SetName(string name)
        {
            Name = new RoomName(name);
        }
        public void SetStatus(RoomStatus status)
        {
            Status = status;
        }
    }
}

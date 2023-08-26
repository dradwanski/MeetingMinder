using Domain.ValueObjects.Room;

namespace Domain.Entities
{
    public class Room
    {
        public int RoomId { get; private set; }
        public RoomName Name { get; private set; }

        private Room()
        {

        }

        public Room(string name)
        {
            Name = new RoomName(name);
        }

        public void SetNewName(string name)
        {
            Name = new RoomName(name);
        }

    }
}

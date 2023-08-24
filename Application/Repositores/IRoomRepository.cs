using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects.Room;

namespace Domain.Repositores
{
    public interface IRoomRepository
    {
        public Task<Room> GetRoomByIdAsync(int roomId);
        public Task<Room> GetRoomByRoomNameAsync(string roomName);
        public Task<List<Room>> GetRoomsAsync();
        public Task CreateRoomAsync(Room room);
        public Task ChangeRoomNameAsync(Room roomName);
        public Task DeleteRoomAsync(Room room);

    }
}

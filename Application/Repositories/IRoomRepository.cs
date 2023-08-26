using Domain.Entities;

namespace Application.Repositories
{
    public interface IRoomRepository
    {
        public Task<Room> GetRoomByIdAsync(int roomId);
        public Task<Room> GetRoomByRoomNameAsync(string roomName);
        public Task<List<Room>> GetRoomsAsync();
        public Task CreateRoomAsync(Room room);
        public Task UpdateRoomAsync(Room roomName);
        public Task DeleteRoomAsync(Room room);

    }
}

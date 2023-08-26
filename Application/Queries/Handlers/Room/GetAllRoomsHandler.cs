using Application.Queries.Dtos;
using Application.Queries.Room;
using Application.Repositories;
using MediatR;

namespace Application.Queries.Handlers.Room
{
    public class GetAllRoomsHandler : IRequestHandler<GetAllRoomsQuery, List<RoomDto>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetAllRoomsHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<List<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetRoomsAsync();

            return rooms.Select(room => new RoomDto(room.RoomId, room.Name.Value)).ToList();
        }
    }
}

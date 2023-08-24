using Application.Queries.Dtos;
using Application.Queries.Room;
using Domain.Repositores;
using MediatR;

namespace Application.Queries.Handlers.Room
{
    public class GetRoomByRoomNameHandler : IRequestHandler<GetRoomByRoomNameQuery, RoomDto>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomByRoomNameHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<RoomDto> Handle(GetRoomByRoomNameQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByRoomNameAsync(request.RoomName);

            return new RoomDto(room.RoomId, room.Name.Value);
        }

    }
}

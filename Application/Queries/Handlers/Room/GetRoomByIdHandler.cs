using Application.Queries.Dtos;
using Application.Queries.Room;
using Domain.Repositores;
using MediatR;

namespace Application.Queries.Handlers.Room
{
    public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdQuery, RoomDto>
    {
        private readonly IRoomRepository _roomRepository;

        public GetRoomByIdHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public async Task<RoomDto> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);

            return new RoomDto(room.RoomId, room.Name.Value);

        }

    }
}

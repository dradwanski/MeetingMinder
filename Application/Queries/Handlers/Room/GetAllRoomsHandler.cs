using System.Security.Cryptography.X509Certificates;
using Application.Queries.Dtos;
using Application.Queries.Room;
using Domain.Entities;
using Domain.Repositores;
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
            List<Room> rooms = await _roomRepository.GetRoomsAsync();

            List<RoomDto> roomsDtos = rooms.Select(room => new RoomDto(room.RoomId, room.Name.Value)).ToList();

            return roomsDtos;
        }
    }
}

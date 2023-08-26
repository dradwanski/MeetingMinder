using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.Room
{
    public record GetRoomByRoomNameQuery : IRequest<RoomDto>
    {
        public string RoomName { get; set; }

    }
}

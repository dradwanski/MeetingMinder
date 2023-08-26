using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.Room
{
    public record GetRoomByIdQuery : IRequest<RoomDto>
    {
        public int RoomId { get; init; }
    }

}



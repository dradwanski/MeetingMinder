using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.Room
{
    public record GetAllRoomsQuery : IRequest<List<RoomDto>>;

}

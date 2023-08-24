using Application.Commands.Dtos.Room;
using MediatR;

namespace Application.Commands.Room
{
    public record CreateRoomCommand : IRequest<CreatedRoomDto>
    {
        public string Name { get; private set; }
    }
}

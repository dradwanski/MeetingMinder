using MediatR;

namespace Application.Commands.Room
{
    public record UpdateRoomCommand : IRequest<Unit>
    {
        public int RoomId { get; init; }
        public string Name { get; init; }
    }
}

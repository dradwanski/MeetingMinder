using MediatR;

namespace Application.Commands.Room
{
    public record UpdateRoomCommand : IRequest<Unit>
    {
        public int RoomId { get; private set; }
        public string Name { get; private set; }
    }
}

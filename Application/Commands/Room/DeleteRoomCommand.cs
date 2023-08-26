using MediatR;

namespace Application.Commands.Room
{
    public record DeleteRoomCommand : IRequest<Unit>
    {
        public int RoomId { get; init; }
    }
}

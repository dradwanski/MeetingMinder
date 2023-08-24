using Application.Commands.Room;
using Application.Exceptions;
using Domain.Repositores;
using MediatR;

namespace Application.Commands.Handlers.Room
{
    public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand, Unit>
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteRoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.RoomId);

            if (room is null)
            {
                throw new RoomNotExistException("Room does not exist");
            }

            await _roomRepository.DeleteRoomAsync(room);

            return new Unit();
        }
    }
}

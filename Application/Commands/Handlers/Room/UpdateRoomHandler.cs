using Application.Commands.Room;
using Application.Exceptions;
using Application.Repositories;
using MediatR;

namespace Application.Commands.Handlers.Room
{
    public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly IRoomRepository _roomRepository;

        public UpdateRoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByRoomNameAsync(request.Name);

            if (room is null)
            {
                throw new RoomNotExistException("Room does not exist");
            }

            room.SetNewName(request.Name);

            await _roomRepository.UpdateRoomAsync(room);

            return new Unit();

        }
    }
}

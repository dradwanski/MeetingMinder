using Application.Commands.Dtos.Room;
using Application.Commands.Room;
using Application.Exceptions;
using Domain.Repositores;
using MediatR;

namespace Application.Commands.Handlers.Room
{
    public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, CreatedRoomDto>
    {
        private readonly IRoomRepository _roomRepository;

        public CreateRoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<CreatedRoomDto> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByRoomNameAsync(request.Name);
            if (room is not null)
            {
                throw new RoomExistException("The room with the given name already exists");
            }

            var newRoom = new Domain.Entities.Room(request.Name);

            await _roomRepository.CreateRoomAsync(newRoom);

            return new CreatedRoomDto(newRoom.RoomId);
        }
    }
}

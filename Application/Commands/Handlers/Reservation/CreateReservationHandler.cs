using Application.Commands.Dtos.Reservation;
using Application.Commands.Reservation;
using Application.Exceptions;
using Domain.Repositores;
using MediatR;

namespace Application.Commands.Handlers.Reservation
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, CreatedReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;

        public CreateReservationHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository, IUserRepository userRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
        }


        public async Task<CreatedReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.ReservedRoomId);
            var user = await _userRepository.GetUserByIdAsync(request.ReservedUserId);
            var reservation =
                await _reservationRepository.GetReservationByDatesAsync(request.StartReservationDate,
                    request.EndReservationDate);


            if (room is null)
            {
                throw new RoomNotExistException("The room not exist");
            }

            if (user is null)
            {
                throw new UserNotExistException("The user not exist");
            }

            if (reservation is not null)
            {
                throw new OccupiedRoomException("The room is occupied at the time");
            }

            var newReservation = new Domain.Entities.Reservation(room, user, request.StartReservationDate, request.EndReservationDate);

            var users = await _userRepository.GetUsersByIdAsync(request.InvitedUsersIdList);

            newReservation.Invite(users);

            await _reservationRepository.CreateReservationAsync(newReservation);

            return new CreatedReservationDto(newReservation.ReservationId);
        }
    }
}

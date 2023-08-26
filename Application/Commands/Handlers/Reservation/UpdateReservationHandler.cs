using Application.Commands.Reservation;
using Application.Exceptions;
using Application.Repositories;
using MediatR;

namespace Application.Commands.Handlers.Reservation
{
    public class UpdateReservationHandler : IRequestHandler<UpdateReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;

        public UpdateReservationHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository, IUserRepository userRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            //to samo co w create reservation
            var room = await _roomRepository.GetRoomByIdAsync(request.ReservedRoomId);
            var user = await _userRepository.GetUserByIdAsync(request.ReservedUserId);
            var reservationByDates =
                await _reservationRepository.GetReservationByDatesAsync(request.StartReservationDate,
                    request.EndReservationDate);
            var reservation = await _reservationRepository.GetReservationByIdAsync(request.ReservationId);


            if (room is null)
            {
                throw new RoomNotExistException("The room not exist");
            }

            if (user is null)
            {
                throw new UserNotExistException("The user not exist");
            }

            if (reservationByDates is not null)
            {
                throw new OccupiedRoomException("The room is occupied at the time");
            }
            if (reservation is null)
            {
                throw new ReservationNotFoundException("The reservation not found");
            }

            reservation.ChangeUser(user);
            reservation.ChangeRoom(room);
            reservation.ChangeStartDate(request.StartReservationDate);
            reservation.ChangeEndDate(request.EndReservationDate);

            await _reservationRepository.UpdateReservationAsync(reservation);

            return new Unit();
        }
    }
}

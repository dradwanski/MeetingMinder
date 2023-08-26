using Application.Commands.Dtos.Reservation;
using Application.Commands.Reservation;
using Application.Exceptions;
using Application.Repositories;
using Domain;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Handlers.Reservation
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, CreatedReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWeeklyReservationRepository _weeklyReservationRepository;

        public CreateReservationHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository, IUserRepository userRepository, IWeeklyReservationRepository weeklyReservationRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;
            _weeklyReservationRepository = weeklyReservationRepository;
        }


        public async Task<CreatedReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            //dla wydajnosci jest lepiej jak se pobierzesz i odrazu sprawdzisz czy cos jest nullem a potem kolejne
            //bez sensu pobierac uzytkownika jak pokoj nie istnieje
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

            var weekly = (await _weeklyReservationRepository.GetWeeklyReservationAsync(request.StartReservationDate)) ?? new WeeklyReservation(request.StartReservationDate);

            var newReservation = new Domain.Entities.Reservation(room, user, request.StartReservationDate, request.EndReservationDate);

            var users = await _userRepository.GetUsersByIdAsync(request.InvitedUsersIdList);
            newReservation.Invite(users);
            
            weekly.AddReservation(newReservation, new LimitReservationsForUser());

            await _weeklyReservationRepository.SaveWeeklyReservationAsync(weekly);

            return new CreatedReservationDto(newReservation.ReservationId);
        }
    }
}

using Application.Queries.Dtos;
using Application.Queries.Reservation;
using Application.Repositories;
using MediatR;

namespace Application.Queries.Handlers.Reservation
{
    public class GetReservationsByUserHandler : IRequestHandler<GetReservationsByUserQuery, List<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetReservationsByUserHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<List<ReservationDto>> Handle(GetReservationsByUserQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetReservationsByUserAsync(request.User);

            return reservations.Select(reservation => new ReservationDto(reservation.ReservationId,
                reservation.ReservedRoom.RoomId, reservation.ReservedUser.UserId, reservation.StartReservationDate,
                reservation.EndReservationDate, reservation.InvitedUsers.Select(invitedUser => new InvitedUserDto(invitedUser.User.UserId, invitedUser.UserStatus)).ToList())).ToList();
            
        }
    }
}

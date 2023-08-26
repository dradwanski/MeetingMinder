using Application.Queries.Dtos;
using Application.Queries.Reservation;
using Application.Repositories;
using MediatR;

namespace Application.Queries.Handlers.Reservation
{
    public class GetReservationByDatesHandler : IRequestHandler<GetReservationByDatesQuery, List<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetReservationByDatesHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<List<ReservationDto>> Handle(GetReservationByDatesQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetReservationByDatesAsync(request.StartReservationDate,
                request.EndReservationDate);

            return reservation.Select(reservation => new ReservationDto(reservation.ReservationId, reservation.ReservedRoom.RoomId, reservation.ReservedUser.UserId,
                reservation.StartReservationDate, reservation.EndReservationDate, reservation.InvitedUsers.Select(invitedUser => new InvitedUserDto(invitedUser.User.UserId, invitedUser.UserStatus)).ToList())).ToList();
        }
    }
}

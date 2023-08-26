using Application.Queries.Dtos;
using Application.Queries.Reservation;
using Application.Repositories;
using MediatR;

namespace Application.Queries.Handlers.Reservation
{
    public class GetReservationByIdHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetReservationByIdHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(request.ReservationId);

            return new ReservationDto(reservation.ReservationId, reservation.ReservedRoom.RoomId, reservation.ReservedUser.UserId,
                reservation.StartReservationDate, reservation.EndReservationDate, reservation.InvitedUsers.Select(invitedUser => new InvitedUserDto(invitedUser.User.UserId, invitedUser.UserStatus)).ToList());
        }

    }
}

using Application.Queries.Dtos;
using Application.Queries.Reservation;
using Domain.Repositores;
using MediatR;

namespace Application.Queries.Handlers.Reservation
{
    public class GetAllReservationsHandler : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetAllReservationsHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<List<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Reservation> reservations = await _reservationRepository.GetReservationsAsync();

            List<ReservationDto> reservationDtos = reservations
                .Select(reseervation => new ReservationDto(reseervation.ReservationId,
                    reseervation.ReservedRoom.RoomId, reseervation.ReservedUser.UserId, reseervation.StartReservationDate,
                    reseervation.EndReservationDate, reseervation.InvitedUsers.Select(invitedUser => new InvitedUserDto(invitedUser.User.UserId, invitedUser.UserStatus)).ToList())).ToList();

            return reservationDtos;
        }
    }
}

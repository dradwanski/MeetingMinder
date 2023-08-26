using MediatR;

namespace Application.Commands.Reservation
{
    public record UpdateReservationCommand : IRequest<Unit>
    {
        public int ReservationId { get; init; }
        public int ReservedRoomId { get; init; }
        public int ReservedUserId { get; init; }
        public DateTime StartReservationDate { get; init; }
        public DateTime EndReservationDate { get; init; }
        public List<int> InvitedUsersIdList { get; init; }
    }
}

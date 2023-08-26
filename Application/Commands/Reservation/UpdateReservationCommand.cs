using MediatR;

namespace Application.Commands.Reservation
{
    public record UpdateReservationCommand : IRequest<Unit>
    {
        public int ReservationId { get; set; }
        public int ReservedRoomId { get; set; }
        public int ReservedUserId { get; set; }
        public DateTime StartReservationDate { get; set; }
        public DateTime EndReservationDate { get; set; }
        public List<int> InvitedUsersIdList { get; set; }
    }
}

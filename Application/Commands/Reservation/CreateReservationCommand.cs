using Application.Commands.Dtos.Reservation;
using MediatR;

namespace Application.Commands.Reservation
{
    public record CreateReservationCommand : IRequest<CreatedReservationDto>
    {
        public int ReservedRoomId { get; private set; }
        public int ReservedUserId { get; private set; }
        public DateTime StartReservationDate { get; private set; }
        public DateTime EndReservationDate { get; private set; }

        public List<int> InvitedUsersIdList;
    }
}

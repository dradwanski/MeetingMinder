using Application.Commands.Dtos.Reservation;
using MediatR;

namespace Application.Commands.Reservation
{
    public record CreateReservationCommand : IRequest<CreatedReservationDto>
    {
        public int ReservedRoomId { get; init; }
        public int ReservedUserId { get; init; }
        public DateTime StartReservationDate { get; init; }
        public DateTime EndReservationDate { get; init; }

        public List<int> InvitedUsersIdList { get; init; } = new();
    }
}

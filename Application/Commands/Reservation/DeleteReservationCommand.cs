using MediatR;

namespace Application.Commands.Reservation
{
    public record DeleteReservationCommand : IRequest<Unit>
    {
        public int ReservationId { get; init; }
    }
}

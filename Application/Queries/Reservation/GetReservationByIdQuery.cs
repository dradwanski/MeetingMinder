using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.Reservation
{
    public record GetReservationByIdQuery : IRequest<ReservationDto>
    {
        public int ReservationId { get; init; }
    }
}

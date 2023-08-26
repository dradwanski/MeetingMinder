using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.Reservation
{
    public record GetReservationsByUserQuery : IRequest<List<ReservationDto>>
    {
        public Domain.Entities.User User { get; set; }
    }
}

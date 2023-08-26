using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.Reservation
{
    public record GetAllReservationsQuery : IRequest<List<ReservationDto>>;
}

using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.Reservation
{
    public record GetReservationsByRoomQuery : IRequest<List<ReservationDto>>
    {
        public Domain.Entities.Room Room { get; set; }
    }
}

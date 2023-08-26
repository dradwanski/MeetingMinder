using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.Reservation
{
    public record GetReservationByDatesQuery : IRequest<List<ReservationDto>>
    {
        public DateTime StartReservationDate { get; set; }
        public DateTime EndReservationDate { get; set; }
    }
}

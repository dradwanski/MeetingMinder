using Application.Commands.Reservation;
using Application.Exceptions;
using Application.Repositories;
using MediatR;

namespace Application.Commands.Handlers.Reservation
{
    public class DeleteReservationHandler : IRequestHandler<DeleteReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;

        public DeleteReservationHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(request.ReservationId);

            if (reservation is null)
            {
                throw new ReservationNotFoundException("Reservation not found");
            }

            await _reservationRepository.DeleteReservationAsync(reservation);

            return new Unit();
        }
    }
}

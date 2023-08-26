using Domain.Entities;

namespace Application.Repositories
{
    public interface IReservationRepository
    {
        public Task UpdateReservationAsync(Reservation reservation);
        public Task DeleteReservationAsync(Reservation reservation);
        public Task<Reservation> GetReservationByIdAsync(int reservationId);
        public Task<List<Reservation>> GetReservationByDatesAsync(DateTime startDate, DateTime endDate);
        public Task<List<Reservation>> GetReservationsByRoomAsync(Room room);
        public Task<List<Reservation>> GetReservationsByUserAsync(User user);
        public Task<List<Reservation>> GetReservationsAsync();
    }
}

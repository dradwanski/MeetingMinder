using Domain.Entities;

namespace Application.Repositories
{
    public interface IWeeklyReservationRepository
    {
        public Task<WeeklyReservation?> GetWeeklyReservationAsync(DateTime date);
        public Task<WeeklyReservation> SaveWeeklyReservationAsync(WeeklyReservation weeklyReservation);
    }
}

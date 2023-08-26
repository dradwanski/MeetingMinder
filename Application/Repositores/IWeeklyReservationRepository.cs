using Domain.Entities;

namespace Application.Repositores
{
    public interface IWeeklyReservationRepository
    {
        public Task<WeeklyReservation> GetWeeklyReservationAsync(DateTime date);
        public Task<WeeklyReservation> SaveWeeklyReservationAsync(WeeklyReservation weeklyReservation);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositores
{
    public interface IReservationRepository
    {
        public Task CreateReservationAsync(Reservation reservation);
        public Task UpdateReservationAsync(Reservation reservation);
        public Task DeleteResevationAsync(Reservation reservation);
        public Task<Reservation> GetReservationByIdAsync(int userId);
        public Task<Reservation> GetReservationByDatesAsync(DateTime startDate, DateTime endDate);
        public Task<List<Reservation>> GetReservationsByRoomAsync(Room room);
        public Task<List<Reservation>> GetReservationsByUserAsync(User user);
        public Task<List<Reservation>> GetReservationsAsync();
    }
}

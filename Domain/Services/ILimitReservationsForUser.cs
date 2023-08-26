using Domain.Entities;

namespace Domain.Services
{
    public interface ILimitReservationsForUser
    {
        int GetReservationLimit(User user);
    }
}

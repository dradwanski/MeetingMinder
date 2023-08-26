using Domain.Entities;
using Domain.Services;

namespace Domain
{
    public class LimitReservationsForUser : ILimitReservationsForUser
    {
        public int GetReservationLimit(User user) => user.Role.Name switch
        {
            ValueObjects.Role.RoleName.Boss => int.MinValue,
            ValueObjects.Role.RoleName.Manager => 3,
            ValueObjects.Role.RoleName.User => 1,
            ValueObjects.Role.RoleName => 0
        };
    }
}

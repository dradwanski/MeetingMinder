using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LimitReservationsForUser : ILimitReservationsForUser
    {
        public int GetReservationLimit(User user) => user.Role.Name switch
        {
            ValueObjects.Role.RoleName.Boss => int.MinValue,
            ValueObjects.Role.RoleName.Manager => 3,
            ValueObjects.Role.RoleName.User => 1
        };
    }
}

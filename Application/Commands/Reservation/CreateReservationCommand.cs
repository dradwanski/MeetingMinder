using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Reservation
{
    public record CreateReservationCommand
    {
        public Domain.Entities.Room ReservedRoom { get; private set; }
        public Domain.Entities.User ReservedUser { get; private set; }
        public DateTime StartReservationDate { get; private set; }
        public DateTime EndReservationDate { get; private set; }

        public List<InvitedUser> InvitedUsers = new List<InvitedUser>();
    }
}

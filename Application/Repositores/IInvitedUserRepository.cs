using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects.InvitedUser;

namespace Application.Repositores
{
    public interface IInvitedUserRepository
    {
        public Task<InvitedUserStatus> GetInvitedUserStatusAsync();
        public Task<List<InvitedUser>> GetInvitedUsers(Reservation reservation);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects.InvitedUser
{
    public enum InvitedUserStatus
    {
        Invited,
        Accepted,
        Rejected,
        Canceled
    }
}

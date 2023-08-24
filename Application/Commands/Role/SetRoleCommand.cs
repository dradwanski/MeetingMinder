using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects.Role;
using MediatR;

namespace Application.Commands.Role
{
    public record SetRoleCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public RoleName RoleName { get; set; }
    }
}

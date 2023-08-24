using Application.Commands.Dtos;
using Domain.ValueObjects.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public record UpdateUserCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleName Role { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

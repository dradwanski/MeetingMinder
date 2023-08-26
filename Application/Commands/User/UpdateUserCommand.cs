using Domain.ValueObjects.Role;
using MediatR;

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

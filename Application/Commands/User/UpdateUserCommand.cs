using Domain.ValueObjects.Role;
using MediatR;

namespace Application.Commands.User
{
    public record UpdateUserCommand : IRequest<Unit>
    {
        public int UserId { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public RoleName Role { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
    }
}

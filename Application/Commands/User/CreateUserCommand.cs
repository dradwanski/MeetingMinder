using Application.Commands.Dtos.User;
using Domain.ValueObjects.Role;
using MediatR;

namespace Application.Commands.User
{
    public record CreateUserCommand : IRequest<CreatedUserDto>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public RoleName Role { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }

    }
}

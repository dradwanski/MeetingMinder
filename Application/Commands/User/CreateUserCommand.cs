using Application.Commands.Dtos.User;
using Domain.ValueObjects.Role;
using MediatR;

namespace Application.Commands.User
{
    public record CreateUserCommand : IRequest<CreatedUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleName Role { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}

using Application.Commands.Dtos.User;
using MediatR;

namespace Application.Commands.User
{
    public record RegisterUserCommand : IRequest<RegisterUserDto>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }

    }
}

using Application.Commands.Dtos.User;
using MediatR;

namespace Application.Commands.User
{
    public record LoginUserCommand : IRequest<LoggedUserDto>
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}

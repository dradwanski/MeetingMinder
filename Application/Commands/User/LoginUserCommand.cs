using Application.Commands.Dtos.User;
using MediatR;

namespace Application.Commands.User
{
    public record LoginUserCommand : IRequest<LoggedUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

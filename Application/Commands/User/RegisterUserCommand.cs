using Application.Commands.Dtos.User;
using MediatR;

namespace Application.Commands.User
{
    public record RegisterUserCommand : IRequest<RegisterUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}

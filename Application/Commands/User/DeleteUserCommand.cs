using MediatR;

namespace Application.Commands.User
{
    public record DeleteUserCommand : IRequest<Unit>
    {
        public int UserId { get; init; }
    }
}

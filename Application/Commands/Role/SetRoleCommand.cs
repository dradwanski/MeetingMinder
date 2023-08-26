using Domain.ValueObjects.Role;
using MediatR;

namespace Application.Commands.Role
{
    public record SetRoleCommand : IRequest<Unit>
    {
        public int UserId { get; init; }
        public RoleName RoleName { get; init; }
    }
}

using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.User
{
    public record GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; init; }

    }

}

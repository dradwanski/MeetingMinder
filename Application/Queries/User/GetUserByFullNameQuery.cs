using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.User
{
    public record GetUserByFullNameQuery : IRequest<UserDto>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

    }
}

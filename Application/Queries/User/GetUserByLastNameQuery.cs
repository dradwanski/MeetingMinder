using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.User
{
    public record GetUserByLastNameQuery : IRequest<UserDto>
    {
        public string LastName { get; set; }

    }
}

using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.User
{
    public record GetUserByFirstNameQuery : IRequest<UserDto>
    {
        public string FirstName { get; set; }

    }
}

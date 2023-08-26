using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.User
{
    public record GetUserByFullNameQuery : IRequest<UserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

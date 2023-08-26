using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.User
{
    public record GetUserByMailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }

    }
}

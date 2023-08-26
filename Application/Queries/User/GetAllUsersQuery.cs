using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.User
{
    public record GetAllUsersQuery : IRequest<List<UserDto>>;

}

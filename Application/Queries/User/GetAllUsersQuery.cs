using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries.Dtos;
using MediatR;

namespace Application.Queries.User
{
    public record GetAllUsersQuery : IRequest<List<UserDto>>;

}

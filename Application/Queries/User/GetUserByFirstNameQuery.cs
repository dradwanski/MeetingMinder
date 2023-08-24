using Application.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User
{
    public record GetUserByFirstNameQuery : IRequest<UserDto>
    {
        public string FirstName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Dtos;
using MediatR;

namespace Application.Commands.User
{
    public record DeleteUserCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
    }
}

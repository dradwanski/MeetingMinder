using Application.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Room
{
    public record DeleteRoomCommand : IRequest<Unit>
    {
        public int RoomId { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Dtos;
using Domain.ValueObjects.Room;
using MediatR;

namespace Application.Commands.Room
{
    public record UpdateRoomCommand : IRequest<Unit>
    {
        public int RoomId { get; private set; }
        public string Name { get; private set; }
    }
}

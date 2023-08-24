using Application.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects.Room;

namespace Application.Queries.Room
{
    public record GetRoomByRoomNameQuery : IRequest<RoomDto>
    {
        public string RoomName { get; set; }

    }
}

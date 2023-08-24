using Application.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Room
{
    public record GetAllRoomsQuery : IRequest<List<RoomDto>>;

}

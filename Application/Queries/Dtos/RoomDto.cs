using Domain.ValueObjects.Role;
using Domain.ValueObjects.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Dtos
{
    public record RoomDto(int RoomId, string Name);

}

using Domain.Entities;
using Domain.ValueObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObjects.Role;

namespace Application.Queries.Dtos
{

    public record UserDto(int UserId, string FirstName, string LastName, RoleName Role, string Password, string Email);

}

using Domain.ValueObjects.Role;

namespace Application.Queries.Dtos
{

    public record UserDto(int UserId, string FirstName, string LastName, RoleName Role, string Password, string Email);

}

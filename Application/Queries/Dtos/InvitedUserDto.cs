using Domain.ValueObjects.InvitedUser;

namespace Application.Queries.Dtos
{
    public record InvitedUserDto(int UserId, InvitedUserStatus UserStatus);
}

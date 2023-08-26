namespace Application.Queries.Dtos
{
    public record ReservationDto(int ReservationId,
        int ReservedRoomId,
        int ReservedUserId,
        DateTime StartReservationDate,
        DateTime EndReservationDate,
        List<InvitedUserDto> InvitedUsersIdList);
}

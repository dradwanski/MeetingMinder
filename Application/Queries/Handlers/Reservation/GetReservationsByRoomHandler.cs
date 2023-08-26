using Application.Exceptions;
using Application.Queries.Dtos;
using Application.Queries.Reservation;
using Application.Repositories;
using MediatR;

namespace Application.Queries.Handlers.Reservation
{
    public class GetReservationsByRoomHandler : IRequestHandler<GetReservationsByRoomQuery, List<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        public GetReservationsByRoomHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }
        public async Task<List<ReservationDto>> Handle(GetReservationsByRoomQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.Room.RoomId);

            if (room == null)
            {
                throw new RoomNotExistException("The room is not exist");
            }

            var reservations = await _reservationRepository.GetReservationsByRoomAsync(request.Room);

            return reservations.Select(reservation => new ReservationDto(reservation.ReservationId,
                reservation.ReservedRoom.RoomId, reservation.ReservedUser.UserId, reservation.StartReservationDate, reservation.EndReservationDate,
                reservation.InvitedUsers.Select(invitedUser => new InvitedUserDto(invitedUser.User.UserId, invitedUser.UserStatus)).ToList())).ToList();
           
        }
    }
}

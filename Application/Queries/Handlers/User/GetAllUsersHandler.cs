using Application.Queries.Dtos;
using Application.Queries.User;
using Domain.Repositores;
using MediatR;

namespace Application.Queries.Handlers.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.User> users = await _userRepository.GetUsersAsync();

            List<UserDto> usersDtos = users.Select(user => new UserDto(user.UserId, user.FirstName.Value, user.LastName.Value, user.Role.Name, user.Password.Value, user.Email.Value)).ToList();

            return usersDtos;
        }
    }
}

using Application.Queries.Dtos;
using Application.Queries.User;
using Application.Repositories;
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
            var users = await _userRepository.GetUsersAsync();

            return users.Select(user => new UserDto(user.UserId, user.FirstName.Value, user.LastName.Value, user.Role.Name, user.Password.Value, user.Email.Value)).ToList();
        }
    }
}

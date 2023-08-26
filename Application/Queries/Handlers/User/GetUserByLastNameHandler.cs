using Application.Queries.Dtos;
using Application.Queries.User;
using Application.Repositories;
using MediatR;

namespace Application.Queries.Handlers.User
{
    public class GetUserByLastNameHandler : IRequestHandler<GetUserByLastNameQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByLastNameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByLastNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByLastNameAsync(request.LastName);

            return new UserDto(user.UserId, user.FirstName.Value, user.LastName.Value, user.Role.Name, user.Password.Value, user.Email.Value);
        }
    }
}
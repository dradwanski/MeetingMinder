using Application.Queries.Dtos;
using Application.Queries.User;
using Application.Repositories;
using MediatR;

namespace Application.Queries.Handlers.User
{
    public class GetUserByMailAsync : IRequestHandler<GetUserByMailQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByMailAsync(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByMailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByMailAsync(request.Email);

            return new UserDto(user.UserId, user.FirstName.Value, user.LastName.Value, user.Role.Name, user.Password.Value, user.Email.Value);
        }
    }
}

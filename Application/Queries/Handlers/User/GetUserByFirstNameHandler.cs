using Application.Queries.Dtos;
using Application.Queries.User;
using Domain.Repositores;
using MediatR;

namespace Application.Queries.Handlers.User
{
    public class GetUserByFirstNameHandler : IRequestHandler<GetUserByFirstNameQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByFirstNameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByFirstNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByFirstNameAsync(request.FirstName);

            return new UserDto(user.UserId, user.FirstName.Value, user.LastName.Value, user.Role.Name, user.Password.Value, user.Email.Value);
        }
    }
}
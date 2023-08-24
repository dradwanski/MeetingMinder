using Application.Queries.Dtos;
using Application.Queries.User;
using Domain.Repositores;
using MediatR;

namespace Application.Queries.Handlers.User
{
    public class GetUserByFullNameHandler : IRequestHandler<GetUserByFullNameQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByFullNameHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByFullNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByFullNameAsync(request.FirstName, request.LastName);

            return new UserDto(user.UserId, user.FirstName.Value, user.LastName.Value, user.Role.Name, user.Password.Value, user.Email.Value);
        }
    }
}
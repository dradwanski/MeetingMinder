using Application.Queries.Dtos;
using Application.Queries.User;
using Domain.Repositores;
using MediatR;

namespace Application.Queries.Handlers.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);

            return new UserDto(user.UserId, user.FirstName.Value, user.LastName.Value, user.Role.Name, user.Password.Value, user.Email.Value);

        }

    }
}

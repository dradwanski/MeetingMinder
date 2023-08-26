using Application.Commands.Dtos.User;
using Application.Commands.User;
using Application.Exceptions;
using Domain.Repositores;
using MediatR;

namespace Application.Commands.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByMailAsync(request.Email);

            if (user is not null)
            {
                throw new UserExistException("The user with the given email already exists");
            }

            var newUser = new Domain.Entities.User(request.FirstName, request.LastName, request.Role, request.Password, request.Email);

            await _userRepository.CreateUserAsync(newUser);

            return new CreatedUserDto(newUser.UserId);
        }
    }
}

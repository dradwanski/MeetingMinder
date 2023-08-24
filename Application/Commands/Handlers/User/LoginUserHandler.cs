using Application.Commands.Dtos.User;
using Application.Commands.User;
using Application.Exceptions;
using Domain.Repositores;
using MediatR;

namespace Application.Commands.Handlers.User
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoggedUserDto>
    {
        private readonly IUserRepository _userRepository;
        public LoginUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<LoggedUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByMailAsync(request.Email);
            if (user is null)
            {
                throw new UserNotExistException("User does not exist");
            }

            //weryfikacja hasła


            var token = await _userRepository.LoginAsync(request.Email, request.Password);

            return new LoggedUserDto(token);

        }
    }
}

using Application.Commands.Dtos.User;
using Application.Commands.User;
using Application.Exceptions;
using Application.Repositories;
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
            if (user is null || user.IsDeleted)
            {
                throw new UserNotExistException("User does not exist");
            }

            //TODO: to ci robi twój obiekt User.Password
            //weryfikacja hasła
            
            


            var token = await _userRepository.LoginAsync(request.Email, request.Password);

            return new LoggedUserDto(token);

        }
    }
}

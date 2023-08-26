using Application.Commands.Dtos.User;
using Application.Commands.User;
using Application.Exceptions;
using Application.Repositories;
using Domain.ValueObjects.Role;
using MediatR;

namespace Application.Commands.Handlers.User
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<RegisterUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByMailAsync(request.Email);

            
            //Jak nie jest nullem raczej 
            if (user is not null)
            {
                throw new UserExistException("The user with the given email already exists");
            }
            
            var newUser = new Domain.Entities.User(request.FirstName, request.LastName, (RoleName)0, request.Password, request.Email);

            await _userRepository.RegisterUserAsync(newUser);

            return new RegisterUserDto(newUser.UserId);
        }
    }
}

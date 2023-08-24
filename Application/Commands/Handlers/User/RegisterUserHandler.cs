using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Dtos.User;
using Application.Commands.User;
using Application.Exceptions;
using Application.Repositores;
using Domain.Entities;
using Domain.Repositores;
using MediatR;

namespace Application.Commands.Handlers.User
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
    {
        public readonly IUserRepository _userRepository;
        public readonly IRoleRepository _roleRepository;
        public RegisterUserHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<RegisterUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByMailAsync(request.Email);

            if (user is null)
            {
                throw new UserExistException("The user with the given email already exists");
            }

            var defaultRole = await _roleRepository.GetDefaultRoleAsync();

            var newUser = new User(request.FirstName, request.LastName, defaultRole.Name, request.Password, request.Email);

            _userRepository.RegisterUserAsync(newUser);

            return new RegisterUserDto(newUser.UserId);
        }
    }
}

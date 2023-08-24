using Application.Commands.User;
using Application.Exceptions;
using Domain.Repositores;
using MediatR;

namespace Application.Commands.Handlers.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user is null)
            {
                throw new UserNotExistException("User does not exist");
            }

            user.SetNewEmail(request.Email);
            user.SetNewFirstName(request.FirstName);
            user.SetNewLastName(request.LastName);
            user.SetNewRole(request.Role);
            user.SetNewPassword(request.Password);

            await _userRepository.UpdateUserAsync(user);

            return new Unit();
        }
    }
}

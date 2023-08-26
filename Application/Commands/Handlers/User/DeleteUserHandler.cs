using Application.Commands.User;
using Application.Exceptions;
using Application.Repositories;
using MediatR;

namespace Application.Commands.Handlers.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
            if (user is null)
            {
                throw new UserNotExistException("User does not exist");
            }

            user.Delete();

            await _userRepository.UpdateUserAsync(user);

            return new Unit();
        }
    }
}

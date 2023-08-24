using Application.Commands.User;
using Application.Exceptions;
using Domain.Repositores;
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

            await _userRepository.DeleteUserAsync(user);

            return new Unit();
        }
    }
}

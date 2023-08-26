using Application.Commands.Role;
using Application.Repositories;
using MediatR;

namespace Application.Commands.Handlers.Role
{
    public class SetRoleHandler : IRequestHandler<SetRoleCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public SetRoleHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(SetRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);

            if (user is null)
            {
                throw new Exception("User not found");
            }
            
            user.SetNewRole(request.RoleName);

            await _userRepository.UpdateUserAsync(user);

            return new Unit();
        }
    }
}

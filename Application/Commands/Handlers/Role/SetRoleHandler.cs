using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Role;
using Application.Repositores;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Handlers.Role
{
    public class SetRoleHandler : IRequestHandler<SetRoleCommand, Unit>
    {
        private readonly IRoleRepository _roleRepository;
        public SetRoleHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Unit> Handle(SetRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role(request.RoleName);

            await _roleRepository.SetRoleAsync(request.UserId, role);

            return new Unit();
        }
    }
}

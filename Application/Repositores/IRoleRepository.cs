using Domain.Entities;

namespace Application.Repositores
{
    public interface IRoleRepository
    {
        Task<Role> GetDefaultRoleAsync();
        Task SetRoleAsync(int userId, Role roleName);
    }
}

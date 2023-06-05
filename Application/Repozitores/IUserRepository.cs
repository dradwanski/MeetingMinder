using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitores
{
    public interface IUserRepository
    {
        public Task<User> GetUserByIdAsync(int id);
        public Task<List<User>> GetUsersAsync();
        public Task<User> LoginAsync(string login, string password);
        public Task RegisterAsync(User newUser);
    }
}

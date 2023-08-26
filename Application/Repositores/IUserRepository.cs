using Application;
using Domain.Entities;

namespace Domain.Repositores
{
    public interface IUserRepository
    {
        public Task<User> GetUserByIdAsync(int userId);
        public Task<List<User>> GetUsersByIdAsync(List<int> usersId);
        public Task<User> GetUserByMailAsync(string email);
        public Task<User> GetUserByFirstNameAsync(string firstName);
        public Task<User> GetUserByLastNameAsync(string lastName);
        public Task<User> GetUserByFullNameAsync(string firstName, string lastName);
        public Task<List<User>> GetUsersAsync();
        public Task<Token> LoginAsync(string email, string password);
        public Task CreateUserAsync(User newUser);
        public Task RegisterUserAsync(User newUser);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(User user);

    }
}

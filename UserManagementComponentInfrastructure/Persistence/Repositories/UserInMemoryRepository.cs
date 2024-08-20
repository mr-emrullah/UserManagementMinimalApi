using UserManagementComponentApplication.Interfaces;
using UserManagementComponentApplication.DTOs;

namespace UserManagementComponentInfrastructure.Persistence.Repositories
{
    internal class UserInMemoryRepository : IUserRepository

    {

        // Bellek içi kullanıcı veri deposu
        private readonly List<UserDto> _users = new List<UserDto>();

      
        // Kullanıcıları asenkron olarak listeleme
        public Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return Task.FromResult<IEnumerable<UserDto>>(_users);
        }

        // Belirli bir ID'ye sahip kullanıcıyı asenkron olarak alma
        public Task<UserDto?> GetUserByIdAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        // Yeni bir kullanıcı oluşturma
        public Task CreateUserAsync(UserDto user)
        {
            // Aynı ID'ye sahip bir kullanıcı var mı kontrol et
           
            _users.Add(user);
            return Task.CompletedTask;
        }

        // Var olan kullanıcıyı güncelleme
        public Task<bool> UpdateUserAsync(Guid id, UserDto user)
        {
            var index = _users.FindIndex(u => u.Id == id);
            if (index == -1) return Task.FromResult(false);

            _users[index] = user;
            return Task.FromResult(true);
        }

        // Kullanıcıyı silme
        public Task<bool> DeleteUserAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return Task.FromResult(false);

            _users.Remove(user);
            return Task.FromResult(true);
        }
    }
}
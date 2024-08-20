using UserManagementComponent;

namespace UserManagementComponent
{
    public class UserInMemoryRepository : IUserRepository
    {
        // Bellek içi kullanıcı veri deposu
        private readonly List<User> _users = new List<User>();

        // Kullanıcıları asenkron olarak listeleme
        public Task<IEnumerable<User>> GetUsersAsync()
        {
            return Task.FromResult<IEnumerable<User>>(_users);
        }

        // Belirli bir ID'ye sahip kullanıcıyı asenkron olarak alma
        public Task<User?> GetUserByIdAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        // Yeni bir kullanıcı oluşturma
        public Task CreateUserAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        // Var olan kullanıcıyı güncelleme
        public Task<bool> UpdateUserAsync(Guid id, User user)
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
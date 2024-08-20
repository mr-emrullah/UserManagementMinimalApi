using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagementComponent;

namespace UserManagementComponent
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserMongoRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _users = database.GetCollection<User>("Users");
        }

        // Kullanıcıları asenkron listeleme
        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await _users.Find(user => true).ToListAsync();

        // Belirli bir ID'ye sahip kullanıcıyı asenkron listeleme
        public async Task<User?> GetUserByIdAsync(Guid id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        // Yeni bir kullanıcı oluşturma
        public async Task CreateUserAsync(User user) =>
            await _users.InsertOneAsync(user);

        // Var olan kullanıcıyı güncelleme
        public async Task<bool> UpdateUserAsync(Guid id, User user)
        {
            var result = await _users.ReplaceOneAsync(u => u.Id == id, user);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        // Kullanıcıyı silme
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var result = await _users.DeleteOneAsync(user => user.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}

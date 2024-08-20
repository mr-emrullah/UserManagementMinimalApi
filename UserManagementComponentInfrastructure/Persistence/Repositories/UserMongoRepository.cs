using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserManagementComponentApplication.Interfaces;
using UserManagementComponentApplication.DTOs;
using UserManagementComponentDomain.Entities;


namespace UserManagementComponentInfrastructure
{
    internal class UserMongoRepository : IUserRepository
    {
        private readonly IMongoCollection<UserDto> _users;

        public UserMongoRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _users = database.GetCollection<UserDto>("Users");
        }



        // Kullanıcıları asenkron listeleme
        public async Task<IEnumerable<UserDto>> GetUsersAsync() =>
            await _users.Find(user => true).ToListAsync();

        // Belirli bir ID'ye sahip kullanıcıyı asenkron listeleme
        public async Task<UserDto?> GetUserByIdAsync(Guid id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        // Yeni bir kullanıcı oluşturma
        public async Task CreateUserAsync(UserDto user) =>
            await _users.InsertOneAsync(user);

        // Var olan kullanıcıyı güncelleme
        public async Task<bool> UpdateUserAsync(Guid id, UserDto user)
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
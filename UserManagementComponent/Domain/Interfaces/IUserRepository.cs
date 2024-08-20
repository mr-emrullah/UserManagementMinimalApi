using UserManagementComponent;

namespace UserManagementComponent
{
    public interface IUserRepository
    {

        //Kullanıcıları asenkron listeleme
        Task<IEnumerable<User>> GetUsersAsync();
        //Belirli bir ID'ye sahip kullanıcıyı asenkron listeleme
        Task<User?> GetUserByIdAsync(Guid id);
        //Yeni bir kullanıcı oluşturma
        Task CreateUserAsync(User user);
        // Var olan kullanıcıyı güncelleme
        Task<bool> UpdateUserAsync(Guid id, User user);
        // Kullanıcıyı silme
        Task<bool> DeleteUserAsync(Guid id);
    }
}
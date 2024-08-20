using UserManagementComponentApplication.DTOs;

namespace UserManagementComponentApplication.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    //Belirli bir ID'ye sahip kullanıcıyı asenkron listeleme
    Task<UserDto?> GetUserByIdAsync(Guid id);
    //Yeni bir kullanıcı oluşturma
    Task CreateUserAsync(UserDto user);
    // Var olan kullanıcıyı güncelleme
    Task<bool> UpdateUserAsync(Guid id, UserDto user);
    // Kullanıcıyı silme
    Task<bool> DeleteUserAsync(Guid id);
}
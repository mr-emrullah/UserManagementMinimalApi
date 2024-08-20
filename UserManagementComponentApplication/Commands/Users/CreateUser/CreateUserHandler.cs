using MediatR;
using UserManagementComponentApplication.DTOs;
using UserManagementComponentApplication.Interfaces;

namespace UserManagementComponentApplication.Commands.Users.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, UserDto>
{
    /// <summary>
    /// Handles CreateUserCommand
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns UserDTO object</returns>
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.User;
        await userRepository.CreateUserAsync(user);
        return user;
    }
}
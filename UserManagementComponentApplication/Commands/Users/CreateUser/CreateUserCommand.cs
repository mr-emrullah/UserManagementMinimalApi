using MediatR;
using UserManagementComponentApplication.DTOs;

namespace UserManagementComponentApplication.Commands.Users.CreateUser
{
    public record CreateUserCommand(UserDto User) : IRequest<UserDto>;
}
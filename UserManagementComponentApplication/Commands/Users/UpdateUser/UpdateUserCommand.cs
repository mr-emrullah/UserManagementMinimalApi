using MediatR;
using UserManagementComponentApplication.DTOs;

namespace UserManagementComponentApplication.Commands.Users.UpdateUser
{
    public record UpdateUserCommand(Guid Id, UserDto User) : IRequest<bool>;
}
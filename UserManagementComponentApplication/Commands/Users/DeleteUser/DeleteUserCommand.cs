using MediatR;

namespace UserManagementComponentApplication.Commands.Users.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : IRequest<bool>;
}
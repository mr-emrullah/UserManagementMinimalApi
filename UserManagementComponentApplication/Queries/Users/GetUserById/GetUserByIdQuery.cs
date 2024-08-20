using MediatR;
using UserManagementComponentDomain;
using UserManagementComponentApplication.DTOs;

namespace UserManagementComponentApplication.Queries.Users
{
    public record GetUserByIdQuery(Guid Id) : IRequest<UserDto?>;
}
using MediatR;
using UserManagementComponentApplication.DTOs;

namespace UserManagementComponentApplication.Queries.Users
{
    public record GetUsersQuery() : IRequest<IEnumerable<UserDto>>;

}
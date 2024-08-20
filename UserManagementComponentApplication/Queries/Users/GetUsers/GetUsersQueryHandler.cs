using MediatR;
using UserManagementComponentApplication.Interfaces;
using UserManagementComponentApplication.DTOs;

namespace UserManagementComponentApplication.Queries.Users
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
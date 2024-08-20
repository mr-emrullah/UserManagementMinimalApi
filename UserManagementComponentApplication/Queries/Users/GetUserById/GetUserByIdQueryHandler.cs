using MediatR;
using UserManagementComponentApplication.Interfaces;
using UserManagementComponentDomain;
using UserManagementComponentApplication.DTOs;

namespace UserManagementComponentApplication.Queries.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // Kullanıcıyı repository'den alır
            return await _userRepository.GetUserByIdAsync(request.Id);
        }
    }
}
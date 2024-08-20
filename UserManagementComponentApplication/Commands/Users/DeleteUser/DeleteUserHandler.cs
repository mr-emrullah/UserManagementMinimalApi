using MediatR;
using UserManagementComponentApplication.Interfaces;
using UserManagementComponentDomain;

namespace UserManagementComponentApplication.Commands.Users.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteUserAsync(request.Id);
        }
    }
}
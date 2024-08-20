using MediatR;
using UserManagementComponentApplication.Interfaces;
using UserManagementComponentDomain;

namespace UserManagementComponentApplication.Commands.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcıyı güncelleme ve başarılı olup olmadığını döner
            return await _userRepository.UpdateUserAsync(request.Id, request.User);
        }
    }
}
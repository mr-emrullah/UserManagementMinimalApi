using FluentValidation;
using UserManagementComponentApplication.Commands.Users;
using UserManagementComponentApplication.Commands.Users.DeleteUser;

namespace UserManagementComponentApplication.Commands.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
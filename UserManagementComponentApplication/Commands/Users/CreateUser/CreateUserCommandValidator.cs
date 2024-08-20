using FluentValidation;
using UserManagementComponentApplication.Commands.Users.CreateUser;
using UserManagementComponentApplication.Interfaces;

namespace UserManagementComponentApplication.Commands.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandValidator()
        {

        
            RuleFor(x => x.User.Name)
                .NotEmpty().WithMessage("Adınız Girmeniz Zorunludur*")
                .MaximumLength(50).WithMessage("50 Karakterden az olmak zorundadır");
            RuleFor(x => x.User.LastName)
                .NotEmpty().WithMessage("Soyadı Girmeniz Zorunludur*")
                .MaximumLength(50).WithMessage("50 Karakterden az olmak zorundadır");
            RuleFor(x => x.User.Email)
                .NotEmpty().WithMessage("E-Posta Adresiniz Zorunludur*")
                .EmailAddress().WithMessage("Geçersiz E-Posta Formatı");
        }

       
    }
}
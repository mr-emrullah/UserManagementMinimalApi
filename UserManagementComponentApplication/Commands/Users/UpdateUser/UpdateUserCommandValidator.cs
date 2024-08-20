using FluentValidation;
using UserManagementComponentApplication.Commands.Users.UpdateUser;
using UserManagementComponentApplication.Interfaces;

namespace UserManagementComponentApplication.Commands.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    { 
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID gereklidir*");

            RuleFor(x => x.User.Name)
                .NotEmpty().WithMessage("Adınızı girmeniz zorunludur*")
                .MaximumLength(50).WithMessage("Adınız 50 Karakterden az olmalıdır");

            RuleFor(x => x.User.LastName)
                .NotEmpty().WithMessage("Soyadınızı girmeniz zorunludur*")
                .MaximumLength(50).WithMessage("Soyadınızı 50 Karakterden az olmalıdır");

            RuleFor(x => x.User.Email)
                .NotEmpty().WithMessage("E-Posta Adresi zorunludur.")
                .EmailAddress().WithMessage("Geçersiz E-Posta Adresi Formatı");


        }

     
    }
}
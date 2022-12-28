using FluentValidation;

namespace Project.Application.DTOs.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser inserido.");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email deve ser inserido.");

            RuleFor(x => x.Nickname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Apelido deve ser inserido.");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha deve ser inserido.");

            RuleFor(x => x.Number)
                .NotEmpty()
                .NotNull()
                .WithMessage("Número deve ser inserido.");
        }
    }
}

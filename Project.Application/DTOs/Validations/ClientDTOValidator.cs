using FluentValidation;

namespace Project.Application.DTOs.Validations
{
    public class ClientDTOValidator : AbstractValidator<ClientDTO>
    {
        public ClientDTOValidator()
        {
            RuleFor(x => x.Enterprise)
                .NotEmpty()
                .NotNull()
                .WithMessage("Empresa deve ser inserido.");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome deve ser inserido.");

            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .NotNull()
                .WithMessage("CNPJ deve ser inserido.");

            RuleFor(x => x.CEP)
                .NotNull()
                .NotEmpty()
                .WithMessage("CEP deve ser inserido.");

            RuleFor(x => x.County)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cidade deve ser inserido.");

            RuleFor(x => x.District)
                .NotNull()
                .NotEmpty()
                .WithMessage("Bairro deve ser inserido.");

            RuleFor(x => x.Street)
                .NotEmpty()
                .NotNull()
                .WithMessage("Rua deve ser inserido.");

            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .WithMessage("Número deve ser inserido.");
        }
    }
}

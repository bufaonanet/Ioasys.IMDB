using FluentValidation;
using System;

namespace Ioasys.IMDb.Domain.Models.Validations
{
    public class AdministradorValidation : AbstractValidator<Administrador>
    {
        public AdministradorValidation()

        {
            RuleFor(c => c.Id)
               .NotEqual(Guid.Empty)
               .WithMessage("O Id é inválido");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(6, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }

    }
}

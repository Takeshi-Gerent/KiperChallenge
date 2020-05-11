using Condominium.Application.Commands.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Commands.Validation
{
    public class DwellerDtoValidator : AbstractValidator<DwellerDto>
    {
        public DwellerDtoValidator()
        {
            
            RuleFor(x => x.Name).NotEmpty().WithMessage(x => $"Morador: Nome não informado");
            RuleFor(x => x.BirthDate).NotNull().WithMessage($"Morador: Data de nascimento não informada");
            RuleFor(x => x.Telephone).NotEmpty().WithMessage($"Morador: Telefone não informado");
            RuleFor(x => x.CPF).NotEmpty().WithMessage($"Morador: CPF não informado");
            RuleFor(x => x.Email).NotEmpty().WithMessage($"Morador: e-mail não informado");
        }
    }
}

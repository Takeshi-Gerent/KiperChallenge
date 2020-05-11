using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Commands.Validation
{
    public class UpdateApartmentCommandValidator : AbstractValidator<UpdateApartmentCommand>
    {
        public UpdateApartmentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("Identificador do apartamento não informado").DependentRules(() =>
            {
                RuleFor(x => x.Number).NotEmpty().GreaterThan(0).WithMessage("Número do apartamento é inválido");
                RuleFor(x => x.Dwellers).NotEmpty().WithMessage("Informe ao menos 1 morador");
                RuleForEach(x => x.Dwellers).SetValidator(new DwellerDtoValidator());
            });
        }
    }
}

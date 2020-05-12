using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Broker.Commands.UpdateApartmentCommand
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

    public class DwellerDtoValidator : AbstractValidator<DwellerDto>
    {
        public DwellerDtoValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Morador: Nome não informado");
            RuleFor(x => x.BirthDate).NotNull().WithMessage("Morador: Data de nascimento não informada");
            RuleFor(x => x.Telephone).NotEmpty().WithMessage("Morador: Telefone não informado");
            RuleFor(x => x.CPF).NotEmpty().WithMessage("Morador: CPF não informado");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Morador: e-mail não informado");
        }
    }
}

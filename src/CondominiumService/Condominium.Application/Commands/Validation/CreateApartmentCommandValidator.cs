using Condominium.Application.Commands.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Condominium.Application.Commands.Validation
{
    public class CreateApartmentCommandValidator: AbstractValidator<CreateApartmentCommand>
    {
        public CreateApartmentCommandValidator()
        {
            RuleFor(x => x.Number).GreaterThan(0).WithMessage("Número do apartamento é inválido");
            RuleFor(x => x.Dwellers).NotEmpty().WithMessage("Informe ao menos 1 morador");

            RuleForEach(x => x.Dwellers).SetValidator(new DwellerDtoValidator());
        }        
    }


}

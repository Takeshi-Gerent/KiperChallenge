using FluentValidation;


namespace Condominium.Broker.Commands.CreateApartmentCommand
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

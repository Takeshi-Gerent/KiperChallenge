using FluentValidation;


namespace Condominium.Broker.Commands.UpdateDwellerCommand
{
    public class UpdateDwellerCommandValidator : AbstractValidator<UpdateDwellerCommand>    
    {

        public UpdateDwellerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0).WithMessage("Identificador do morador não informado").DependentRules(() =>
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não informado");
                RuleFor(x => x.BirthDate).NotNull().WithMessage("Data de nascimento não informada");
                RuleFor(x => x.Telephone).NotEmpty().WithMessage("Telefone não informado");
                RuleFor(x => x.CPF).NotEmpty().WithMessage("CPF não informado");
                RuleFor(x => x.Email).NotEmpty().WithMessage("e-mail não informado");
            });
        }
    }
}

using Condominium.Broker.Commands.UpdateDwellerCommand;
using Condominium.Core.Domain;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class UpdateDwellerHandler : IRequestHandler<UpdateDwellerCommand, UpdateDwellerCommandResult>
    {
        private readonly IUnitOfWork uow;

        public UpdateDwellerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<UpdateDwellerCommandResult> Handle(UpdateDwellerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Validate(request);
                var dweller = await uow.DwellerRepository.GetById(request.Id);
                if (dweller == null) throw new Exception("Morador não localizado.");
                dweller.UpdateData(request.Name, request.BirthDate.Value, request.Telephone, request.CPF, request.Email);
                uow.DwellerRepository.Update(dweller);
                await uow.CommitChanges();
                return new UpdateDwellerCommandResult { Success = true, Message = "Morador atualizado com sucesso.", DwellerId = dweller.Id };
            }
            catch (Exception e)
            {
                return new UpdateDwellerCommandResult { Success = false, Message = e.Message };
            }            
        }

        private static void Validate(UpdateDwellerCommand command)
        {
            var validator = new UpdateDwellerCommandValidator();
            var validationResult = validator.Validate(command);

            if (!validationResult.IsValid)
            {
                var errorBuilder = new StringBuilder();
                errorBuilder.AppendLine("Morador informado inválido.");
                foreach (var error in validationResult.Errors)
                {
                    errorBuilder.AppendLine(error.ErrorMessage);
                }
                throw new Exception(errorBuilder.ToString());
            }
        }
    }
}

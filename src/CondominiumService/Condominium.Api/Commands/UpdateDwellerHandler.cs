using Condominium.Api.Domain;
using Condominium.Application.Commands;
using Condominium.Application.Commands.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class UpdateDwellerHandler : IRequestHandler<UpdateDwellerCommand, int>
    {
        private readonly IUnitOfWork uow;

        public UpdateDwellerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<int> Handle(UpdateDwellerCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            var dweller = await uow.DwellerRepository.GetById(request.Id);
            if (dweller == null) throw new Exception("Morador não localizado.");
            dweller.UpdateData(request.Name, request.BirthDate.Value, request.Telephone, request.CPF, request.Email);
            uow.DwellerRepository.Update(dweller);
            await uow.CommitChanges();

            return dweller.Id;
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

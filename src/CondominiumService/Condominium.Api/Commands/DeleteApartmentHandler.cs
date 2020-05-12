using Condominium.Broker.Commands;
using Condominium.Core.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class DeleteApartmentHandler : IRequestHandler<DeleteApartmentCommand, DeleteApartmentResult>
    {
        private readonly IUnitOfWork uow;

        public DeleteApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<DeleteApartmentResult> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Validate(request);
                var apartment = uow.ApartmentRepository.GetById(request.Id);

                if (apartment == null) throw new Exception("Apartamento não localizado.");
                uow.ApartmentRepository.Delete(request.Id);
                await uow.CommitChanges();

                return new DeleteApartmentResult { Success = true, Message = "Apartamento excluído com sucesso." };
            }
            catch (Exception e)
            {
                return new DeleteApartmentResult { Success = false, Message = e.Message};
            }
        }

        private static void Validate(DeleteApartmentCommand command)
        {
            if (command.Id <= 0)
                throw new Exception("Informe o identificador do apartamento a ser removido");
        }

    }
}

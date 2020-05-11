using Condominium.Api.Domain;
using Condominium.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class DeleteApartmentHandler : IRequestHandler<DeleteApartmentCommand, bool>
    {
        private readonly IUnitOfWork uow;

        public DeleteApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            var apartment = uow.ApartmentRepository.GetById(request.Id);

            if (apartment == null) throw new Exception("Apartamento não localizado.");
            uow.ApartmentRepository.Delete(request.Id);
            await uow.CommitChanges();

            return true;
        }

        private static void Validate(DeleteApartmentCommand command)
        {
            if (command.Id <= 0)
                throw new Exception("Informe o identificador do apartamento a ser removido");
        }

    }
}

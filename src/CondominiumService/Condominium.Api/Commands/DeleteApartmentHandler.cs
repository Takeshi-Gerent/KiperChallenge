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
            var apartment = uow.ApartmentRepository.GetById(request.Id);

            if (apartment == null) return false;
            uow.ApartmentRepository.Delete(request.Id);
            await uow.CommitChanges();

            return true;
        }

    }
}

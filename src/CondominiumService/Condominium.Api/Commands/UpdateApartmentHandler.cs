using Condominium.Api.Domain;
using Condominium.Api.Mappers;
using Condominium.Application.Commands;
using Condominium.Application.Commands.Dtos;
using MediatR;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class UpdateApartmentHandler : IRequestHandler<UpdateApartmentCommand, ApartmentDto>
    {
        private readonly IUnitOfWork uow;

        public UpdateApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<ApartmentDto> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartment = uow.ApartmentRepository.GetById(request.Id);

            apartment.UpdateData(request.Number, request.Block, DwellerMapper.FromDwellerDtoList(request.Dwellers));
            uow.ApartmentRepository.Update(apartment);            
            await uow.CommitChanges();

            return new ApartmentDto { Id = apartment.Id };
        }

    }
}

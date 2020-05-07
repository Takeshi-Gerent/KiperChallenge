using Condominium.Api.Domain;
using Condominium.Api.Mappers;
using Condominium.Application.Commands;
using Condominium.Application.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Commands
{
    public class CreateApartmentHandler : IRequestHandler<CreateApartmentCommand, ApartmentDto>
    {
        private readonly IUnitOfWork uow;

        public CreateApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<ApartmentDto> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartment = Apartment.New(request.Number, request.Block, DwellerMapper.FromDwellerDtoList(request.Dwellers));

            uow.ApartmentRepository.Add(apartment);
            //throw new NotImplementedException();
            await uow.CommitChanges();

            return new ApartmentDto { Id = apartment.Id };
        }
    }
}

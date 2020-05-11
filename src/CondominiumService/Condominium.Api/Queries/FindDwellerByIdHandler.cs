using Condominium.Api.Domain;
using Condominium.Application.Queries;
using Condominium.Application.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Queries
{
    public class FindDwellerByIdHandler : IRequestHandler<FindDwellerByIdQuery, Application.Queries.Dtos.DwellerDto>
    {
        private readonly IUnitOfWork uow;

        public FindDwellerByIdHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        public async Task<Application.Queries.Dtos.DwellerDto> Handle(FindDwellerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.DwellerRepository.GetById(request.Id);
            return new Application.Queries.Dtos.DwellerDto
            {
                Id = result.Id,
                Name = result.Name,
                BirthDate = result.BirthDate,
                Telephone = result.Telephone,
                CPF = result.CPF,
                Email = result.Email,
                Apartment = new DwellerApartmentDto { 
                    Id = result.Apartment.Id, 
                    Block = result.Apartment.Block, 
                    Number = result.Apartment.Number }
            };
        }
    }
}

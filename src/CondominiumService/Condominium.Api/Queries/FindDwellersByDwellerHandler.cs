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
    public class FindDwellersByDwellerHandler : IRequestHandler<FindDwellersByDwellerQuery, FindDwellersQueryResult>
    {
        private readonly IUnitOfWork uow;

        public FindDwellersByDwellerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<FindDwellersQueryResult> Handle(FindDwellersByDwellerQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.DwellerRepository.GetAllByDweller(
                request.Dweller.Name,
                request.Dweller.BirthDate,
                request.Dweller.Telephone,
                request.Dweller.CPF,
                request.Dweller.Email
                );

            var response = new FindDwellersQueryResult();

            result.ToList().ForEach(p =>
            {
                response.Dwellers.Add(new Application.Queries.Dtos.DwellerDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    Telephone = p.Telephone,
                    CPF = p.CPF,
                    Email = p.Email,
                    Apartment = new DwellerApartmentDto
                    {
                        Id = p.Apartment.Id,
                        Block = p.Apartment.Block,
                        Number = p.Apartment.Number
                    }
                });
            });

            return response;
        }
    }
}

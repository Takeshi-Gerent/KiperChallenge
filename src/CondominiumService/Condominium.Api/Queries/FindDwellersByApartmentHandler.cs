using Condominium.Api.Domain;
using Condominium.Application.Queries;
using Condominium.Application.Queries.Dtos;
using MediatR;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Queries
{
    public class FindDwellersByApartmentHandler : IRequestHandler<FindDwellersByApartmentQuery, FindDwellersQueryResult>
    {
        private readonly IUnitOfWork uow;

        public FindDwellersByApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<FindDwellersQueryResult> Handle(FindDwellersByApartmentQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.DwellerRepository.GetAllByApartment(request.Apartment.Number, request.Apartment.Block);

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

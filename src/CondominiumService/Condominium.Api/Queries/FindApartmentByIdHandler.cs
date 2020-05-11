using Condominium.Api.Domain;
using Condominium.Api.Mappers;
using Condominium.Application.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Queries
{
    public class FindApartmentByIdHandler : IRequestHandler<FindApartmentByIdQuery, FindApartmentByIdQueryResult>
    {
        private readonly IUnitOfWork uow;

        public FindApartmentByIdHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<FindApartmentByIdQueryResult> Handle(FindApartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.ApartmentRepository.GetById(request.Id);
            return new FindApartmentByIdQueryResult
            {
                Id = result.Id,
                Number = result.Number,
                Block = result.Block,
                Dwellers = DwellerMapper.ToDwellerDtoList(result.Dwellers)
            };
        }
    }    
}

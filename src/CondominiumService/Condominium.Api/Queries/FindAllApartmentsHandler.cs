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
    public class FindAllApartmentsHandler: IRequestHandler<FindAllApartmentsQuery, IEnumerable<ApartmentDto>>
    {
        private readonly IUnitOfWork uow;

        public FindAllApartmentsHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<ApartmentDto>> Handle(FindAllApartmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.ApartmentRepository.GetAll();
            return result.Select(p => new ApartmentDto{ 
                Id = p.Id,
                Number = p.Number,
                Block = p.Block,
                DwellersCount = p.Dwellers.Count()
            });
        }
    }
}

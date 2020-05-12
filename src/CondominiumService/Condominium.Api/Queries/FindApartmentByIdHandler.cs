using Condominium.Broker.Queries.FindApartmentByIdQuery;
using Condominium.Core.Domain;
using MediatR;
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
                Dwellers = ToDwellerDtoList(result.Dwellers)
            };
        }

        private static IEnumerable<DwellerDto> ToDwellerDtoList(IEnumerable<Dweller> dwellers)
        {
            return dwellers?.Select(d => ToDwellerDto(d));
        }

        private static DwellerDto ToDwellerDto(Dweller dweller)
        {
            return new DwellerDto
            {
                Id = dweller.Id,
                Name = dweller.Name,
                BirthDate = dweller.BirthDate,
                Telephone = dweller.Telephone,
                CPF = dweller.CPF,
                Email = dweller.Email
            };
        }
    }    
}

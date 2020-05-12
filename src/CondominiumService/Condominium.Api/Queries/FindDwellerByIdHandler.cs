using Condominium.Broker.Queries.FindDwellerByIdQuery;
using Condominium.Core.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Queries
{
    public class FindDwellerByIdHandler : IRequestHandler<FindDwellerByIdQuery, FindDwellerByIdQueryResult>
    {
        private readonly IUnitOfWork uow;

        public FindDwellerByIdHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        public async Task<FindDwellerByIdQueryResult> Handle(FindDwellerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.DwellerRepository.GetById(request.Id);
            return new FindDwellerByIdQueryResult
            {
                Id = result.Id,
                Name = result.Name,
                BirthDate = result.BirthDate,
                Telephone = result.Telephone,
                CPF = result.CPF,
                Email = result.Email,
                Apartment = ToApartmentDto(result.Apartment)
            };
        }

        private static ApartmentDto ToApartmentDto(Apartment apartment)
        {
            return new ApartmentDto
            {
                Id = apartment.Id,
                Block = apartment.Block,
                Number = apartment.Number
            };
        }
    }
}

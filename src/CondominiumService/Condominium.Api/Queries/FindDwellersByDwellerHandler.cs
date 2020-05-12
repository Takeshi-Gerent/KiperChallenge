using Condominium.Broker.Queries.FindDwellersByDwellerQuery;
using Condominium.Core.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Queries
{
    public class FindDwellersByDwellerHandler : IRequestHandler<FindDwellersByDwellerQuery, FindDwellersByDwellerQueryResult>
    {
        private readonly IUnitOfWork uow;

        public FindDwellersByDwellerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<FindDwellersByDwellerQueryResult> Handle(FindDwellersByDwellerQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.DwellerRepository.GetAllByDweller(
                request.Name,
                request.BirthDate,
                request.Telephone,
                request.CPF,
                request.Email
                );
            var response = new FindDwellersByDwellerQueryResult();
            response.Dwellers.AddRange(result.Select(p => ToDwellerDto(p)));
            return response;
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
                Email = dweller.Email,
                Apartment = ToApartmentDto(dweller.Apartment)
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

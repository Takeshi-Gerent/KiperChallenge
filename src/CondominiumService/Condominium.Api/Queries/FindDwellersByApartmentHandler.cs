using Condominium.Broker.Queries.FindDwellersByApartmentQuery;
using Condominium.Core.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Queries
{
    public class FindDwellersByApartmentHandler : IRequestHandler<FindDwellersByApartmentQuery, FindDwellersByApartmentQueryResult>
    {
        private readonly IUnitOfWork uow;

        public FindDwellersByApartmentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<FindDwellersByApartmentQueryResult> Handle(FindDwellersByApartmentQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.DwellerRepository.GetAllByApartment(request.Number, request.Block);
            var response = new FindDwellersByApartmentQueryResult();
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

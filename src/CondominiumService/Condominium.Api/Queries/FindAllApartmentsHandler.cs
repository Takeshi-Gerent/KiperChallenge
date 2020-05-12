using Condominium.Broker.Queries.FindAllApartmentsQuery;
using Condominium.Core.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condominium.Api.Queries
{
    public class FindAllApartmentsHandler: IRequestHandler<FindAllApartmentsQuery, FindAllApartmentsQueryResult>
    {
        private readonly IUnitOfWork uow;

        public FindAllApartmentsHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<FindAllApartmentsQueryResult> Handle(FindAllApartmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.ApartmentRepository.GetAll();

            var response = new FindAllApartmentsQueryResult();
            response.Apartments.AddRange(result.Select(p => ToApartmentDto(p)));
            return response;
        }

        private static ApartmentDto ToApartmentDto(Apartment apartment)
        {
            return new ApartmentDto
            {
                Id = apartment.Id,
                Number = apartment.Number,
                Block = apartment.Block,
                DwellersCount = apartment.Dwellers.Count()
            };
        }
    }
}

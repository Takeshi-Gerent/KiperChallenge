using MediatR;

namespace Condominium.Broker.Queries.FindDwellersByApartmentQuery
{
    public class FindDwellersByApartmentQuery : IRequest<FindDwellersByApartmentQueryResult>
    {
        public string Number { get; set; }
        public string Block { get; set; }
    }
}

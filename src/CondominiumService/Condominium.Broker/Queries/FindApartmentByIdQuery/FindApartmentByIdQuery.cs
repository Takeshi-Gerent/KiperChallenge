using MediatR;

namespace Condominium.Broker.Queries.FindApartmentByIdQuery
{
    public class FindApartmentByIdQuery : IRequest<FindApartmentByIdQueryResult>
    {
        public int Id { get; set; }
    }
}

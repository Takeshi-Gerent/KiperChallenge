using MediatR;

namespace Condominium.Broker.Queries.FindDwellerByIdQuery
{
    public class FindDwellerByIdQuery: IRequest<FindDwellerByIdQueryResult>
    {
        public int Id { get; set; }
    }
}

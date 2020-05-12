using MediatR;

namespace Condominium.Broker.Queries.FindDwellersByDwellerQuery
{
    public class FindDwellersByDwellerQuery : IRequest<FindDwellersByDwellerQueryResult>
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Telephone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}

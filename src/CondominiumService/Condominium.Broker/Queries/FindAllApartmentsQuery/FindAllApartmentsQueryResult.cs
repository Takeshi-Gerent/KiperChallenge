using System.Collections.Generic;

namespace Condominium.Broker.Queries.FindAllApartmentsQuery
{
    public class FindAllApartmentsQueryResult
    {
        public List<ApartmentDto> Apartments { get; set; } = new List<ApartmentDto>();
    }

    public class ApartmentDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
        public int DwellersCount { get; set; }
    }
}

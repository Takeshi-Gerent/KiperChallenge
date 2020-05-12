using Condominium.Broker.Queries.FindApartmentByIdQuery;
using System.Collections.Generic;

namespace Condominium.Test.TestData
{
    internal static class TestApartmentFindByIdFactory
    {
        internal static FindApartmentByIdQueryResult MyApartment()
        {
            return new FindApartmentByIdQueryResult
            {
                Number = 211,
                Block = "B",
                Id = 1,
                Dwellers = new List<DwellerDto>()
            };
        }

        internal static FindApartmentByIdQueryResult Neightbor()
        {
            return new FindApartmentByIdQueryResult
            {
                Number = 212,
                Block = "B",
                Id = 2,
                Dwellers = new List<DwellerDto>()
            };
        }
    }
}

using Condominium.Core.Domain;
using System;
using System.Collections.Generic;


namespace Condominium.Test.TestData
{
    internal static class TestGetAllApartmentFactory
    {
        internal static Apartment Apartment211()
        {
            var dwellers = new List<Dweller>();
            dwellers.Add(Dweller.FromId(
                1,
                "Marcelo Gerent",
                new DateTime(1982, 04, 27),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            dwellers.Add(Dweller.FromId(
                2,
                "Zezinho Gerent",
                new DateTime(1980, 01, 01),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            return Apartment.FromId(1, 211, "B", dwellers);                            
        }

        internal static Apartment Apartment212()
        {
            var dwellers = new List<Dweller>();
            dwellers.Add(Dweller.FromId(
                3,
                "Ciclana da silva",
                new DateTime(1982, 04, 27),
                "(48) 99619-0445",
                "123.456.789-09",
                "ciclana@gmail.com",
                null));
            return Apartment.FromId(2, 212, "B", dwellers);
        }


        internal static Apartment Apartment201()
        {
            var dwellers = new List<Dweller>();
            dwellers.Add(Dweller.FromId(
                4,
                "Fulano Santos",
                new DateTime(1982, 04, 27),
                "(48) 99619-0445",
                "123.456.789-09",
                "fulano@gmail.com",
                null));
            dwellers.Add(Dweller.FromId(
                5,
                "Beltrano Santos",
                new DateTime(1980, 01, 01),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            dwellers.Add(Dweller.FromId(
                6,
                "Joaozinho Santos",
                new DateTime(1980, 01, 01),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));

            return Apartment.FromId(3, 201, "A", dwellers);
        }
    }
}

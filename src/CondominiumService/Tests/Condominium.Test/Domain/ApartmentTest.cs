using Condominium.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Condominium.Test.Domain
{
    public class ApartmentTest
    {
        private IEnumerable<Dweller> DwellerList()
        {
            var list = new List<Dweller>();
            list.Add(Dweller.FromId(
                0,
                "Marcelo Gerent",
                new DateTime(1982, 04, 27),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            list.Add(Dweller.FromId(
                0,
                "Zezinho Gerent",
                new DateTime(1980, 01, 01),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            return list;
        }

        private IEnumerable<Dweller> UpdateDwellerListOld()
        {
            var list = new List<Dweller>();
            list.Add(Dweller.FromId(
                1,
                "Marcelo Gerent",
                new DateTime(1982, 04, 27),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            list.Add(Dweller.FromId(
                2,
                "Zezinho Gerent",
                new DateTime(1980, 01, 01),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            return list;
        }

        private IEnumerable<Dweller> UpdateDwellerListNew()
        {
            var list = new List<Dweller>();
            list.Add(Dweller.FromId(
                1,
                "Marcelo Gerent",
                new DateTime(1982, 04, 27),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            list.Add(Dweller.FromId(
                0,
                "Huguinho Gerent",
                new DateTime(1980, 01, 01),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null));
            return list;
        }

        [Fact]
        public void New()
        {
            var apartment = Apartment.New(211, "B", DwellerList());

            Assert.Equal(211, apartment.Number);
            Assert.Equal("B", apartment.Block);

            Assert.Collection<Apartment>(apartment.Dwellers.Select(p => p.Apartment), item => Assert.Equal(item, apartment), item => Assert.Equal(item, apartment));

        }

        [Fact]
        public void New_WithoutDweller()
        {
            var ex = Assert.Throws<ArgumentException>(() => Apartment.New(211, "B", Enumerable.Empty<Dweller>()));

            Assert.Equal("Informe ao menos 1 morador", ex.Message);
        }

        [Fact]
        public void FromId()
        {
            var apartment = Apartment.FromId(1, 211, "B", DwellerList());
            Assert.Equal(1, apartment.Id);
            Assert.Equal(211, apartment.Number);
            Assert.Equal("B", apartment.Block);

            Assert.Collection<Apartment>(apartment.Dwellers.Select(p => p.Apartment), item => Assert.Equal(item, apartment), item => Assert.Equal(item, apartment));
        }

        [Fact]
        public void UpdateData()
        {
            var apartment = Apartment.FromId(1, 211, "B", UpdateDwellerListOld());
            apartment.UpdateData(213, "C", UpdateDwellerListNew());
            Assert.Equal(1, apartment.Id);
            Assert.Equal(213, apartment.Number);
            Assert.Equal("C", apartment.Block);


            Assert.Contains( "Marcelo Gerent", apartment.Dwellers.Select(p => p.Name));
            Assert.Contains( "Huguinho Gerent", apartment.Dwellers.Select(p => p.Name));
        }

    }
}

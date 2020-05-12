using Condominium.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Condominium.Test.Domain
{
    public class DwellerTest
    {
        [Fact]
        public void New()
        {
            var dweller = Dweller.New("Marcelo Gerent", new DateTime(1982, 04, 27), "(48) 99619-0445", "123.456.789-09", "marcelo@gmail.com");
            Assert.Equal(0, dweller.Id);
            Assert.Equal("Marcelo Gerent", dweller.Name);
            Assert.Equal(new DateTime(1982,04,27), dweller.BirthDate);
            Assert.Equal("(48) 99619-0445", dweller.Telephone);
            Assert.Equal("123.456.789-09", dweller.CPF);
            Assert.Equal("marcelo@gmail.com", dweller.Email);
        }

        [Fact]
        public void FromId()
        {
            var dweller = Dweller.FromId(
                1,
                "Marcelo Gerent",
                new DateTime(1982, 04, 27),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null);

            Assert.Equal(1, dweller.Id);
            Assert.Equal("Marcelo Gerent", dweller.Name);
            Assert.Equal(new DateTime(1982, 04, 27), dweller.BirthDate);
            Assert.Equal("(48) 99619-0445", dweller.Telephone);
            Assert.Equal("123.456.789-09", dweller.CPF);
            Assert.Equal("marcelo@gmail.com", dweller.Email);
        }

        [Fact]
        public void UpdateData()
        {
            var dweller = Dweller.FromId(
                1,
                "Marcelo Gerent",
                new DateTime(1982, 04, 27),
                "(48) 99619-0445",
                "123.456.789-09",
                "marcelo@gmail.com",
                null);
            dweller.UpdateData("Marcelo Takeshi Gerent", new DateTime(1982, 04, 01), "(48) 9619-0445", "234.567.890-12", "takeshi@gmail.com");

            Assert.Equal(1, dweller.Id);
            Assert.Equal("Marcelo Takeshi Gerent", dweller.Name);
            Assert.Equal(new DateTime(1982, 04, 01), dweller.BirthDate);
            Assert.Equal("(48) 9619-0445", dweller.Telephone);
            Assert.Equal("234.567.890-12", dweller.CPF);
            Assert.Equal("takeshi@gmail.com", dweller.Email);
        }
    }
}

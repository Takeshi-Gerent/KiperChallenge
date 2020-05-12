using System;
using System.Collections.Generic;

namespace Condominium.Broker.Queries.FindDwellersByApartmentQuery
{
    public class FindDwellersByApartmentQueryResult
    {
        public List<DwellerDto> Dwellers { get; set; } = new List<DwellerDto>();
    }

    public class DwellerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Telephone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public ApartmentDto Apartment { get; set; }
    }

    public class ApartmentDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
    }



}

using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Broker.Queries.FindDwellerByIdQuery
{
    public class FindDwellerByIdQueryResult
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

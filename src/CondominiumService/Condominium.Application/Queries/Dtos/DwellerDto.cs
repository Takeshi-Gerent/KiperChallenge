using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Queries.Dtos
{
    public class DwellerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Telephone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DwellerApartmentDto Apartment { get; set; }
    }

    public class DwellerApartmentDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
    }
}

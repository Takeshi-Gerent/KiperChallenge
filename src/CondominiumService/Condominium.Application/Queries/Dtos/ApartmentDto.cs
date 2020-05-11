using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Queries.Dtos
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
        public int DwellersCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Commands.Dtos
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Block { get; set; }
        public IEnumerable<DwellerDto> Dwellers { get; set; }
    }
}

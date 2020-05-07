using Condominium.Application.Commands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Commands
{
    public class CreateApartmentCommand: IRequest<ApartmentDto>
    {
        public int Number { get; set; }
        public string Block { get; set; }
        public IEnumerable<DwellerDto> Dwellers { get; set; }
    }
}

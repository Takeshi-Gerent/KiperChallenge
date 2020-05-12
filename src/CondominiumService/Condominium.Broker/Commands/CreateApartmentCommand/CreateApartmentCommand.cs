using MediatR;
using System;
using System.Collections.Generic;

namespace Condominium.Broker.Commands.CreateApartmentCommand
{
    public class CreateApartmentCommand: IRequest<CreateApartmentCommandResult>
    {
        public int Number { get; set; }
        public string Block { get; set; }
        public IEnumerable<DwellerDto> Dwellers { get; set; }
    }

    public class DwellerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Telephone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}

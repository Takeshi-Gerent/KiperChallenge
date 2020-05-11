using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Commands
{
    public class UpdateDwellerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Telephone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}

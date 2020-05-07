using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Commands
{
    public class DeleteApartmentCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Broker.Commands.UpdateApartmentCommand
{
    public class UpdateApartmentCommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ApartmentId { get; set; }
    }
}

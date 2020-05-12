using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Broker.Commands.UpdateDwellerCommand
{
    public class UpdateDwellerCommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int DwellerId { get; set; }
    }
}


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Queries
{
    public class FindDwellerByIdQuery: IRequest<Application.Queries.Dtos.DwellerDto>
    {
        public int Id { get; set; }
    }
}

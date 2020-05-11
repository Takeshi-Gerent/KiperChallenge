using Condominium.Application.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Queries
{
    public class FindDwellersByDwellerQuery : IRequest<FindDwellersQueryResult>
    {
        public DwellerQueryDto Dweller { get; set; }
    }
}

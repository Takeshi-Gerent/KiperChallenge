using Condominium.Application.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Queries
{
    public class FindDwellersQueryResult
    {
        public List<Application.Queries.Dtos.DwellerDto> Dwellers { get; set; } = new List<Application.Queries.Dtos.DwellerDto>();
    }




}

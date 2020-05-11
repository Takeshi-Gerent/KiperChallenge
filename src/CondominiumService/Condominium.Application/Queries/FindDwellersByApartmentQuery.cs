using Condominium.Application.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Queries
{
    public class FindDwellersByApartmentQuery : IRequest<FindDwellersQueryResult>
    {
        public ApartmentQueryDto Apartment { get; set; }
    }
}

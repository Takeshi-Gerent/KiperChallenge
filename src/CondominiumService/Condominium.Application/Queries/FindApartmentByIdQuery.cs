using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Condominium.Application.Queries
{
    public class FindApartmentByIdQuery : IRequest<FindApartmentByIdQueryResult>
    {
        public int Id { get; set; }
    }
}

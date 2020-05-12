using System.Threading.Tasks;
using Condominium.Broker.Commands.UpdateDwellerCommand;
using Condominium.Broker.Queries.FindDwellerByIdQuery;
using Condominium.Broker.Queries.FindDwellersByApartmentQuery;
using Condominium.Broker.Queries.FindDwellersByDwellerQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Condominium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DwellerController : ControllerBase
    {
        private readonly IMediator mediator;

        public DwellerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindById([FromRoute] int id)
        {
            var result = await mediator.Send(new FindDwellerByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateDwellerCommand cmd)
        {
            var result = await mediator.Send(cmd);
            return new JsonResult(result);
        }

        [HttpGet("byapartment")]
        public async Task<ActionResult> FindByApartment([FromQuery] FindDwellersByApartmentQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }

        [HttpGet("bydweller")]
        public async Task<ActionResult> FindByDweller([FromQuery] FindDwellersByDwellerQuery request)
        {
            var result = await mediator.Send(request);
            return new JsonResult(result);
        }
    }
}
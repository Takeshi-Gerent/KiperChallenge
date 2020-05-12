using System.Threading.Tasks;
using Condominium.Broker.Commands;
using Condominium.Broker.Commands.CreateApartmentCommand;
using Condominium.Broker.Commands.UpdateApartmentCommand;
using Condominium.Broker.Queries.FindAllApartmentsQuery;
using Condominium.Broker.Queries.FindApartmentByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Condominium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApartmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]        
        public async Task<ActionResult> GetAll()
        {
            var result = await mediator.Send(new FindAllApartmentsQuery());
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await mediator.Send(new FindApartmentByIdQuery { Id = id });
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateApartmentCommand cmd)
        {
            var result = await mediator.Send(cmd);
            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateApartmentCommand cmd)
        {
            var result = await mediator.Send(cmd);
            return new JsonResult(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] DeleteApartmentCommand cmd)
        {
            var result = await mediator.Send(cmd);
            return new JsonResult(result);
        }

    }
}
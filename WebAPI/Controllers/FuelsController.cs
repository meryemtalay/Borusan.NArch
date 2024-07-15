using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FuelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
        {
            CreatedFuelResponse? response = await _mediator.Send(createFuelCommand);
            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllFuelsQuery getAllFuelsQuery = new();
            var response = await _mediator.Send(getAllFuelsQuery);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteFuelCommand deleteFuelCommand = new() { Id = id };
            DeletedFuelResponse? response = await _mediator.Send(deleteFuelCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateFuelCommand updateFuelCommand)
        {


            UpdatedFuelResponse? response = await _mediator.Send(updateFuelCommand);
            return Ok(response);
        }
    }
}

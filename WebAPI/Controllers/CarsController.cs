using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
        {
            CreatedCarResponse? response = await _mediator.Send(createCarCommand);
            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCarsQuery getAllCarsQuery = new();
            var response = await _mediator.Send(getAllCarsQuery);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteCarCommand deleteCarCommand = new() { Id = id };
            DeletedCarResponse? response = await _mediator.Send(deleteCarCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateCarCommand)
        {


            UpdatedCarResponse? response = await _mediator.Send(updateCarCommand);
            return Ok(response);
        }
    }
}

using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
        {
            CreatedColorResponse? response = await _mediator.Send(createColorCommand);
            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllColorsQuery getAllColorsQuery = new();
            var response = await _mediator.Send(getAllColorsQuery);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteColorCommand deleteColorCommand = new() { Id = id };
            DeletedColorResponse? response = await _mediator.Send(deleteColorCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColorCommand)
        {


            UpdatedColorResponse? response = await _mediator.Send(updateColorCommand);
            return Ok(response);
        }
    }
}

using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransmissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionsCommand)
        {
            CreatedTransmissionResponse? response = await _mediator.Send(createTransmissionsCommand);
            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllTransmissionsQuery getAllTransmissionssQuery = new();
            var response = await _mediator.Send(getAllTransmissionssQuery);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteTransmissionCommand deleteTransmissionsCommand = new() { Id = id };
            DeletedTransmissionResponse? response = await _mediator.Send(deleteTransmissionsCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateTransmissionCommand updateTransmissionsCommand)
        {


            UpdatedTransmissionResponse? response = await _mediator.Send(updateTransmissionsCommand);
            return Ok(response);
        }
    }
}

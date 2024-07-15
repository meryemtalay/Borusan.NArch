using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateModelCommand createModelCommand)
        {
            CreatedModelResponse? response = await _mediator.Send(createModelCommand);
            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllModelsQuery getAllModelsQuery = new();
            var response = await _mediator.Send(getAllModelsQuery);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteModelCommand deleteModelCommand = new() { Id = id };
            DeletedModelResponse? response = await _mediator.Send(deleteModelCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateModelCommand updateModelCommand)
        {


            UpdatedModelResponse? response = await _mediator.Send(updateModelCommand);
            return Ok(response);
        }
    }
}

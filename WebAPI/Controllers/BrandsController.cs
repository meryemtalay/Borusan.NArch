using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse? response = await _mediator.Send(createBrandCommand);
            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllBrandsQuery getAllBrandsQuery = new();
            var response = await _mediator.Send(getAllBrandsQuery);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteBrandCommand deleteBrandCommand = new() { Id = id };
            DeletedBrandResponse? response = await _mediator.Send(deleteBrandCommand);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
           

            UpdatedBrandResponse? response = await _mediator.Send(updateBrandCommand);
            return Ok(response);
        }
    }
}

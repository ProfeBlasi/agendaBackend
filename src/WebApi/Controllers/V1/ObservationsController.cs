using Application.UseCase.V1.ObservationsOperations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok((await _mediator.Send(new GetObservationsRequest())).Content);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok((await _mediator.Send(new GetByIdObservationsRequest { Id = id })).Content);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostObservationsRequest body)
            => Ok(await _mediator.Send(body));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateObservationsRequest body)
            => Ok(await _mediator.Send(body));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _mediator.Send(new DeleteObservationsRequest { Id = id }));
    }
}

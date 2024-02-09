using Application.UseCase.V1.DiaNoLaborableOperations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiaNoLaborableController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok((await _mediator.Send(new GetDiaNoLaborableRequest())).Content);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok((await _mediator.Send(new GetByIdDiaNoLaborableRequest { Id = id })).Content);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDiaNoLaborableRequest postDiaNoLaborableRequest)
            => Ok(await _mediator.Send(postDiaNoLaborableRequest));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDiaNoLaborableRequest updateDiaNoLaborableRequest)
            => Ok(await _mediator.Send(updateDiaNoLaborableRequest));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _mediator.Send(new DeleteDiaNoLaborableRequest { Id = id }));
    }
}

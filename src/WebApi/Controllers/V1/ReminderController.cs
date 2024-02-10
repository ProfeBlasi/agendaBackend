using Application.UseCase.V1.ReminderOperations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok((await _mediator.Send(new GetReminderRequest())).Content);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok((await _mediator.Send(new GetByIdReminderRequest { Id = id })).Content);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostReminderRequest body)
            => Ok(await _mediator.Send(body));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReminderRequest body)
            => Ok(await _mediator.Send(body));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _mediator.Send(new DeleteReminderRequest { Id = id }));
    }
}

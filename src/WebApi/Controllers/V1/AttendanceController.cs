using Application.UseCase.V1.AttendanceOperations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1;

[Route("api/[controller]")]
[ApiController]
public class AttendanceController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok((await _mediator.Send(new GetAttendanceRequest())).Content);

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok((await _mediator.Send(new GetByIdAttendanceRequest { Id = id })).Content);

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostAttendanceRequest body)
        => Ok(await _mediator.Send(body));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAttendanceRequest body)
        => Ok(await _mediator.Send(body));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _mediator.Send(new DeleteAttendanceRequest { Id = id }));
}

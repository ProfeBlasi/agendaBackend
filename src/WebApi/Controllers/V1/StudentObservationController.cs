using Application.UseCase.V1.StudentObservationOperations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentObservationController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok((await _mediator.Send(new GetStudentObservationRequest())).Content);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok((await _mediator.Send(new GetByIdStudentObservationRequest { Id = id })).Content);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostStudentObservationRequest body)
            => Ok(await _mediator.Send(body));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentObservationRequest body)
            => Ok(await _mediator.Send(body));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _mediator.Send(new DeleteStudentObservationRequest { Id = id }));
    }
}

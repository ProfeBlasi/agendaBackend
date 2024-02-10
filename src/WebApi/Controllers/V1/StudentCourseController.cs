using Application.UseCase.V1.StudentCourseOperations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok((await _mediator.Send(new GetStudentCourseRequest())).Content);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok((await _mediator.Send(new GetByIdStudentCourseRequest { Id = id })).Content);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostStudentCourseRequest body)
            => Ok(await _mediator.Send(body));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCourseRequest body)
            => Ok(await _mediator.Send(body));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _mediator.Send(new DeleteStudentCourseRequest { Id = id }));
    }
}

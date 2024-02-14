using Application.UseCase.V1.CourseOperations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok((await _mediator.Send(new GetCourseRequest())).Content);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok((await _mediator.Send(new GetByIdCourseRequest { Id = id })).Content);

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post([FromBody] PostCourseRequest body)
            => Ok(await _mediator.Send(body));

        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateCourseRequest body)
            => Ok(await _mediator.Send(body));

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _mediator.Send(new DeleteCourseRequest { Id = id }));
    }
}

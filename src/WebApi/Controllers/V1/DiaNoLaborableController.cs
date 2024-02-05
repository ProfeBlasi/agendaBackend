using Application.UseCase.V1.DiaNoLaborableOperations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiaNoLaborableController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiaNoLaborableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiaNoLaborable()
            => Ok((await _mediator.Send(new GetDiaNoLaborableRequest())).Content);
    }
}

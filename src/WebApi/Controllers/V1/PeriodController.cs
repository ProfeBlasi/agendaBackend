﻿using Application.UseCase.V1.PeriodOperations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok((await _mediator.Send(new GetPeriodRequest())).Content);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok((await _mediator.Send(new GetByIdPeriodRequest { Id = id })).Content);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostPeriodRequest body)
            => Ok(await _mediator.Send(body));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePeriodRequest body)
            => Ok(await _mediator.Send(body));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _mediator.Send(new DeletePeriodRequest { Id = id }));
    }
}

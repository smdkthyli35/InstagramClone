using InstagramClone.Application.Features.Commands.Reply.CreateReply;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RepliesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] CreateReplyCommandRequest createReplyCommandRequest)
        {
            CreateReplyCommandResponse response = await _mediator.Send(createReplyCommandRequest);
            return Ok(response);
        }
    }
}

using InstagramClone.Application.Features.Commands.Reply.CreateReply;
using InstagramClone.Application.Features.Commands.Reply.DeleteReply;
using InstagramClone.Application.Features.Commands.Reply.UpdateReply;
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteReply([FromRoute] DeleteReplyCommandRequest deleteReplyCommandRequest)
        {
            DeleteReplyCommandResponse response = await _mediator.Send(deleteReplyCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReply([FromBody] UpdateReplyCommandRequest updateReplyCommandRequest)
        {
            UpdateReplyCommandResponse response = await _mediator.Send(updateReplyCommandRequest);
            return Ok(response);
        }
    }
}

using InstagramClone.Application.Features.Commands.Comment.CreateComment;
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
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommandRequest createCommentCommandRequest)
        {
            CreateCommentCommandResponse response = await _mediator.Send(createCommentCommandRequest);
            return Ok(response);
        }
    }
}

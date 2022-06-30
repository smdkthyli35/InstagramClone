﻿using InstagramClone.Application.Features.Commands.Comment.CreateComment;
using InstagramClone.Application.Features.Commands.Comment.DeleteComment;
using InstagramClone.Application.Features.Commands.Comment.UpdateComment;
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] DeleteCommentCommandRequest deleteCommentCommandRequest)
        {
            DeleteCommentCommandResponse response = await _mediator.Send(deleteCommentCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommandRequest updateCommentCommandRequest)
        {
            UpdateCommentCommandResponse response = await _mediator.Send(updateCommentCommandRequest);
            return Ok(response);
        }
    }
}
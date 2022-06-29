using InstagramClone.Application.Features.Commands.Post.CreatePost;
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
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(CreatePostCommandRequest createPostCommandRequest)
        {
            CreatePostCommandResponse response = await _mediator.Send(createPostCommandRequest);
            return Ok();
        }
    }
}

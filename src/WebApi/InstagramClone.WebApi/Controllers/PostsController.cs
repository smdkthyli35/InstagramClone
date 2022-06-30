using InstagramClone.Application.Features.Commands.Post.CreatePost;
using InstagramClone.Application.Features.Commands.Post.DeletePost;
using InstagramClone.Application.Features.Commands.Post.UpdatePost;
using InstagramClone.Application.Features.Queries.GetByIdPost;
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdPost([FromRoute] GetByIdPostQueryRequest getByIdPostQueryRequest)
        {
            GetByIdPostQueryResponse response = await _mediator.Send(getByIdPostQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(CreatePostCommandRequest createPostCommandRequest)
        {
            CreatePostCommandResponse response = await _mediator.Send(createPostCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePost([FromRoute] DeletePostCommandRequest deletePostCommandRequest)
        {
            DeletePostCommandResponse response = await _mediator.Send(deletePostCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostCommandRequest updatePostCommandRequest)
        {
            UpdatePostCommandResponse response = await _mediator.Send(updatePostCommandRequest);
            return Ok(response);
        }
    }
}

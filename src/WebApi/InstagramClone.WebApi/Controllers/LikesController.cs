using InstagramClone.Application.Features.Commands.Like.CreateLike;
using InstagramClone.Application.Features.Commands.Like.DeleteLike;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstagramClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLike(CreateLikeCommandRequest createLikeCommandRequest)
        {
            CreateLikeCommandResponse response = await _mediator.Send(createLikeCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteLike([FromRoute] DeleteLikeCommandRequest deleteLikeCommandRequest)
        {
            DeleteLikeCommandResponse response = await _mediator.Send(deleteLikeCommandRequest);
            return Ok(response);
        }
    }
}

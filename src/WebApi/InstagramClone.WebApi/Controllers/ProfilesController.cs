using InstagramClone.Application.Features.Commands.ProfileImageFile.RemoveProfileImage;
using InstagramClone.Application.Features.Commands.ProfileImageFile.UploadProfileImage;
using InstagramClone.Application.Features.Queries.ProfileImageFile.GetProfileImages;
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
    [Authorize(AuthenticationSchemes ="Admin")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadProfileImage([FromQuery] UploadProfileImageCommandRequest uploadProfileImageCommandRequest)
        {
            uploadProfileImageCommandRequest.Files = Request.Form.Files;
            UploadProfileImageCommandResponse response = await _mediator.Send(uploadProfileImageCommandRequest);
            return Ok();
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveProfileImage([FromRoute] RemoveProfileImageCommandRequest removeProfileImageCommandRequest, [FromQuery] string imageId)
        {
            removeProfileImageCommandRequest.ImageId = imageId;
            RemoveProfileImageCommandResponse response = await _mediator.Send(removeProfileImageCommandRequest);
            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProfileImages([FromRoute] GetProfileImagesQueryRequest getProfileImagesQueryRequest)
        {
            List<GetProfileImagesQueryResponse> responses = await _mediator.Send(getProfileImagesQueryRequest);
            return Ok(responses);
        }
    }
}

using InstagramClone.Application.Features.Commands.ProfileImageFile.UploadProfileImage;
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
    }
}

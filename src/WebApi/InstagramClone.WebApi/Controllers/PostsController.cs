﻿using InstagramClone.Application.Features.Commands.Post.CreatePost;
using InstagramClone.Application.Features.Commands.Post.DeletePost;
using InstagramClone.Application.Features.Commands.Post.UpdatePost;
using InstagramClone.Application.Features.Commands.PostImageFile.RemovePostImage;
using InstagramClone.Application.Features.Commands.PostImageFile.UploadPostImage;
using InstagramClone.Application.Features.Queries.Post.GetAllProduct;
using InstagramClone.Application.Features.Queries.Post.GetByIdPost;
using InstagramClone.Application.Features.Queries.Post.SearchByPost;
using InstagramClone.Application.Features.Queries.PostImageFile.GetPostImages;
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
    //[Authorize(AuthenticationSchemes = "Admin")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, int pageSize)
        {
            var posts = await _mediator.Send(new GetAllPostQueryRequest(page, pageSize));
            return Ok(posts);
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

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadProductImage([FromQuery] UploadPostImageCommandRequest uploadPostImageCommandRequest)
        {
            uploadPostImageCommandRequest.Files = Request.Form.Files;
            UploadPostImageCommandResponse response = await _mediator.Send(uploadPostImageCommandRequest);
            return Ok();
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemovePostImageCommandRequest removePostImageCommandRequest, [FromQuery] string imageId)
        {
            removePostImageCommandRequest.ImageId = imageId;
            RemovePostImageCommandResponse response = await _mediator.Send(removePostImageCommandRequest);
            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetPostImages([FromRoute] GetPostImagesQueryRequest getPostImagesQueryRequest)
        {
            List<GetPostImagesQueryResponse> responses = await _mediator.Send(getPostImagesQueryRequest);
            return Ok(responses);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search([FromQuery] SearchByPostQueryRequest searchByPostQueryRequest)
        {
            List<Application.ViewModels.SearchPostViewModel> searchPosts = await _mediator.Send(searchByPostQueryRequest);
            return Ok(searchPosts);
        }
    }
}

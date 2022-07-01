using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.PostImageFile.RemovePostImage
{
    public class RemovePostImageCommandHandler : IRequestHandler<RemovePostImageCommandRequest, RemovePostImageCommandResponse>
    {
        private readonly IPostRepository _postRepository;

        public RemovePostImageCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<RemovePostImageCommandResponse> Handle(RemovePostImageCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post? post = await _postRepository.Table.Include(p => p.PostImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            Domain.Entities.PostImageFile? postImageFile = post.PostImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (postImageFile != null)
                post?.PostImageFiles.Remove(postImageFile);

            await _postRepository.SaveAsync();
            return new();
        }
    }
}

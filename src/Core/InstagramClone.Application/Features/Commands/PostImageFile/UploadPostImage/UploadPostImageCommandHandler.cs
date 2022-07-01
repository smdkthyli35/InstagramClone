using InstagramClone.Application.Abstractions.Storage;
using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.PostImageFile.UploadPostImage
{
    public class UploadPostImageCommandHandler : IRequestHandler<UploadPostImageCommandRequest, UploadPostImageCommandResponse>
    {
        private readonly IStorageService _storageService;
        private readonly IPostImageFileRepository _postImageFileRepository;
        private readonly IPostRepository _postRepository;

        public UploadPostImageCommandHandler(IStorageService storageService, IPostImageFileRepository postImageFileRepository, IPostRepository postRepository)
        {
            _storageService = storageService;
            _postImageFileRepository = postImageFileRepository;
            _postRepository = postRepository;
        }

        public async Task<UploadPostImageCommandResponse> Handle(UploadPostImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            Domain.Entities.Post post = await _postRepository.GetByIdAsync(request.Id);

            await _postImageFileRepository.AddRangeAsync(result.Select(r => new Domain.Entities.PostImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Posts = new List<Domain.Entities.Post>() { post }
            }).ToList());

            await _postImageFileRepository.SaveAsync();

            return new();
        }
    }
}

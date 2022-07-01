using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.PostImageFile.GetPostImages
{
    public class GetPostImagesQueryHandler : IRequestHandler<GetPostImagesQueryRequest, List<GetPostImagesQueryResponse>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IConfiguration _configuration;

        public GetPostImagesQueryHandler(IPostRepository postRepository, IConfiguration configuration)
        {
            _postRepository = postRepository;
            _configuration = configuration;
        }

        public async Task<List<GetPostImagesQueryResponse>> Handle(GetPostImagesQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post? post = await _postRepository.Table.Include(p => p.PostImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            return post?.PostImageFiles.Select(p => new GetPostImagesQueryResponse
            {
                Path = $"{_configuration["BaseStorageUrl"]}/{p.Path}",
                FileName = p.FileName,
                Id = p.Id
            }).ToList();
        }
    }
}

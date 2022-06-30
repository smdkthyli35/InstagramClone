using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.GetByIdPost
{
    public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQueryRequest, GetByIdPostQueryResponse>
    {
        private readonly IPostRepository _postRepository;

        public GetByIdPostQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<GetByIdPostQueryResponse> Handle(GetByIdPostQueryRequest request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id, false);

            return new()
            {
                Id = post.Id.ToString(),
                Description = post.Description
            };
        }
    }
}

using InstagramClone.Application.Interfaces.Repositories;
using InstagramClone.Application.RequestParameters.Page;
using InstagramClone.Application.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.Post.GetAllProduct
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQueryRequest, PagedViewModel<GetPostDetailViewModel>>
    {
        private readonly IPostRepository _postRepository;

        public GetAllPostQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PagedViewModel<GetPostDetailViewModel>> Handle(GetAllPostQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _postRepository.GetAll();

            query = query.Include(i => i.Likes)
                         .Include(i => i.PostImageFiles)
                         .Include(i => i.Replies);

            var list = query.Select(i => new GetPostDetailViewModel()
            {
                Id = i.Id,
                Description = i.Description,
                CreatedDate = i.CreatedDate,
                UpdatedDate = i.UpdatedDate
            });

            var posts = await list.GetPaged(request.Page, request.PageSize);
            return posts;
        }
    }
}

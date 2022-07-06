using InstagramClone.Application.Pipelines.Caching;
using InstagramClone.Application.RequestParameters.Page;
using InstagramClone.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.Post.GetAllProduct
{
    public class GetAllPostQueryRequest : BasePagedQuery, IRequest<PagedViewModel<GetPostDetailViewModel>>, ICachableRequest
    {
        public GetAllPostQueryRequest(int page, int pageSize) : base(page, pageSize)
        {
        }

        public bool BypassCache { get; set; }

        public string CacheKey => "post-list";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}

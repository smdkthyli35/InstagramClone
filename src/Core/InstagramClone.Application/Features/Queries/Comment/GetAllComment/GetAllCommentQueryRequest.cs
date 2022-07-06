using InstagramClone.Application.Pipelines.Caching;
using InstagramClone.Application.RequestParameters.Page;
using InstagramClone.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.Comment.GetAllComment
{
    public class GetAllCommentQueryRequest : BasePagedQuery, IRequest<PagedViewModel<GetCommentDetailViewModel>>, ICachableRequest
    {
        public GetAllCommentQueryRequest(int page, int pageSize) : base(page, pageSize)
        {
        }

        public bool BypassCache { get; set; }

        public string CacheKey => "comments-list";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}

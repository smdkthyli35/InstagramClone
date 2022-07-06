using InstagramClone.Application.Pipelines.Caching;
using InstagramClone.Application.RequestParameters.Page;
using InstagramClone.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryRequest : IRequest<GetAllUserQueryResponse>, ICachableRequest
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;

        public bool BypassCache { get; set; }
        public string CacheKey => "users-list";
        public TimeSpan? SlidingExpiration { get; set; }
    }
}

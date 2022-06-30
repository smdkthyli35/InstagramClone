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
    public class GetAllCommentQueryRequest : BasePagedQuery, IRequest<PagedViewModel<GetCommentDetailViewModel>>
    {
        public GetAllCommentQueryRequest(int page, int pageSize) : base(page, pageSize)
        {
        }
    }
}

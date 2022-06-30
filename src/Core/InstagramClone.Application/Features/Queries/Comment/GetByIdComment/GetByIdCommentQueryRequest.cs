using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.Comment.GetByIdComment
{
    public class GetByIdCommentQueryRequest : IRequest<GetByIdCommentQueryResponse>
    {
        public string Id { get; set; }
    }
}

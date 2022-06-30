using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.Comment.GetByIdComment
{
    public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQueryRequest, GetByIdCommentQueryResponse>
    {
        private readonly ICommentRepository _commentRepository;

        public GetByIdCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetByIdCommentQueryResponse> Handle(GetByIdCommentQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comment comment = await _commentRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Id = comment.Id.ToString(),
                PostId = comment.PostId.ToString(),
                Description = comment.Description
            };
        }
    }
}

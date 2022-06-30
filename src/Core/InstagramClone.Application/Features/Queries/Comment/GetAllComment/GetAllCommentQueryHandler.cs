using AutoMapper;
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

namespace InstagramClone.Application.Features.Queries.Comment.GetAllComment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQueryRequest, PagedViewModel<GetCommentDetailViewModel>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetAllCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<PagedViewModel<GetCommentDetailViewModel>> Handle(GetAllCommentQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _commentRepository.GetAll();

            query = query.Include(i => i.Post);

            var list = query.Select(i => new GetCommentDetailViewModel()
            {
                Id = i.Id,
                PostId = i.PostId,
                Description = i.Description,
                CreatedDate = i.CreatedDate,
                UpdatedDate = i.UpdatedDate
            });

            var comments = await list.GetPaged(request.Page, request.PageSize);
            return comments;
        }
    }
}

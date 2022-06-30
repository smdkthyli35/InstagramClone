using AutoMapper;
using InstagramClone.Application.Exceptions;
using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var dbComment = await _commentRepository.GetByIdAsync(request.Id);
            if (dbComment is null)
                throw new DatabaseValidationException("Böyle bir yorum bulunamadı!");

            _mapper.Map(request, dbComment);

            var rows = _commentRepository.Update(dbComment);
            await _commentRepository.SaveAsync();
            return new()
            {
                Id = dbComment.Id.ToString(),
                PostId = dbComment.PostId.ToString(),
                Description = dbComment.Description
            };
        }
    }
}

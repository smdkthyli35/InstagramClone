using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Reply.DeleteReply
{
    public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommandRequest, DeleteReplyCommandResponse>
    {
        private readonly IReplyRepository _replyRepository;

        public DeleteReplyCommandHandler(IReplyRepository replyRepository)
        {
            _replyRepository = replyRepository;
        }

        public async Task<DeleteReplyCommandResponse> Handle(DeleteReplyCommandRequest request, CancellationToken cancellationToken)
        {
            await _replyRepository.RemoveAsync(request.Id);
            await _replyRepository.SaveAsync();
            return new();
        }
    }
}

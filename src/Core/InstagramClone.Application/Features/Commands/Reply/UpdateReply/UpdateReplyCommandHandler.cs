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

namespace InstagramClone.Application.Features.Commands.Reply.UpdateReply
{
    public class UpdateReplyCommandHandler : IRequestHandler<UpdateReplyCommandRequest, UpdateReplyCommandResponse>
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IMapper _mapper;

        public UpdateReplyCommandHandler(IReplyRepository replyRepository, IMapper mapper)
        {
            _replyRepository = replyRepository;
            _mapper = mapper;
        }

        public async Task<UpdateReplyCommandResponse> Handle(UpdateReplyCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Reply dbReply = await _replyRepository.GetByIdAsync(request.Id);
            if (dbReply is null)
                throw new ReplyUpdatedFailedException();

            _mapper.Map(request, dbReply);

            var rows = _replyRepository.Update(dbReply);
            await _replyRepository.SaveAsync();

            return new()
            {
                Id = dbReply.Id
            };
        }
    }
}

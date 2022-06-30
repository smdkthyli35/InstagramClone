using AutoMapper;
using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Reply.CreateReply
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommandRequest, CreateReplyCommandResponse>
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IMapper _mapper;

        public CreateReplyCommandHandler(IReplyRepository replyRepository, IMapper mapper)
        {
            _replyRepository = replyRepository;
            _mapper = mapper;
        }

        public async Task<CreateReplyCommandResponse> Handle(CreateReplyCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedReply = _mapper.Map<Domain.Entities.Reply>(request);
            await _replyRepository.AddAsync(mappedReply);
            await _replyRepository.SaveAsync();
            return new()
            {
                ReplyId = mappedReply.Id.ToString()
            };
        }
    }
}

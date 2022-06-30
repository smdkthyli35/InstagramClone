using AutoMapper;
using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Post.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, DeletePostCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<DeletePostCommandResponse> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _postRepository.RemoveAsync(request.Id);
            await _postRepository.SaveAsync();
            return new();
        }
    }
}

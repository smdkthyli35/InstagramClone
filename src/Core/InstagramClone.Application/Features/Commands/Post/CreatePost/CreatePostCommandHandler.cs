using AutoMapper;
using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Post.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedPost = _mapper.Map<Domain.Entities.Post>(request);
            await _postRepository.AddAsync(mappedPost);
            await _postRepository.SaveAsync();
            return new();
        }
    }
}

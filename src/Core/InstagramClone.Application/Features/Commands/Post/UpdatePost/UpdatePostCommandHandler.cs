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

namespace InstagramClone.Application.Features.Commands.Post.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Post dbPost = await _postRepository.GetByIdAsync(request.Id);
            if (dbPost is null)
                throw new PostUpdatedFailedException();

            _mapper.Map(request, dbPost);

            var rows = _postRepository.Update(dbPost);
            await _postRepository.SaveAsync();
            return new()
            {
                Id = dbPost.Id
            };
        }
    }
}

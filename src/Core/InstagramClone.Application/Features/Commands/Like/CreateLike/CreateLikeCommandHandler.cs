using AutoMapper;
using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Like.CreateLike
{
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommandRequest, CreateLikeCommandResponse>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public CreateLikeCommandHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<CreateLikeCommandResponse> Handle(CreateLikeCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedLike = _mapper.Map<Domain.Entities.Like>(request);
            await _likeRepository.AddAsync(mappedLike);
            await _likeRepository.SaveAsync();
            return new()
            {
                PostId = mappedLike.PostId.ToString()
            };
        }
    }
}

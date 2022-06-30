using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Like.DeleteLike
{
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommandRequest, DeleteLikeCommandResponse>
    {
        private readonly ILikeRepository _likeRepository;

        public DeleteLikeCommandHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<DeleteLikeCommandResponse> Handle(DeleteLikeCommandRequest request, CancellationToken cancellationToken)
        {
            await _likeRepository.RemoveAsync(request.Id);
            await _likeRepository.SaveAsync();
            return new()
            {
                LikeId = request.Id
            };
        }
    }
}

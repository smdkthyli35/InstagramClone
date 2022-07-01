using InstagramClone.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.ProfileImageFile.RemoveProfileImage
{
    public class RemoveProfileImageCommandHandler : IRequestHandler<RemoveProfileImageCommandRequest, RemoveProfileImageCommandResponse>
    {
        private readonly IProfileRepository _profileRepository;

        public RemoveProfileImageCommandHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<RemoveProfileImageCommandResponse> Handle(RemoveProfileImageCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Profile? profile = await _profileRepository.Table.Include(p => p.ProfileImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            Domain.Entities.ProfileImageFile? profileImageFile = profile.ProfileImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (profileImageFile != null)
                profile?.ProfileImageFiles.Remove(profileImageFile);

            await _profileRepository.SaveAsync();
            return new();
        }
    }
}
